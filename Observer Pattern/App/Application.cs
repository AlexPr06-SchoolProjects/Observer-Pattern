using Observer_Pattern.Factories.NotifierFactory;
using Observer_Pattern.Factories.NotifierFactory.NotifierCreatorTypes;
using Observer_Pattern.Managers;
using Observer_Pattern.Notifiers;
using Observer_Pattern.Notifiers.Data;
using Observer_Pattern.User;
using Spectre.Console;
using UserType = Observer_Pattern.User.User;

namespace Observer_Pattern.App
{
    internal class NotifyingApplication
    {
        // NotifyingData
        private NotifiableData NotifyingData { get; set; }

        private List<Notifier> NotifierList { get; set; }
        private NotiferManager NotiferManager { get; set; }

        // Pool of creators 
        private List<NotifiableCreator> NotifiableCreators { get; set; }

        // Creatprs
        private TelegramNotifierCreator TelegramNotifierCreator { get; set; }
        private SMSNotifierCreator SMSNotifierCreator { get; set; }
        private EmailNotifierCreator EmailNotifierCreator { get; set; }
        private SlackNotifierCreator SlackNotifierCreator { get; set; }
        private SoundNotifierCreator SoundNotifierCreator { get; set; }

        public NotifyingApplication(NotifiableData notifyingData)
        {
            NotifyingData = notifyingData;

            NotiferManager = new NotiferManager();
            NotifierList = new List<Notifier>();

            NotifiableCreators = new List<NotifiableCreator>();

            TelegramNotifierCreator = new TelegramNotifierCreator(NotifyingData);
            NotifiableCreators.Add(TelegramNotifierCreator);

            SMSNotifierCreator = new SMSNotifierCreator(NotifyingData);
            NotifiableCreators.Add(SMSNotifierCreator);

            EmailNotifierCreator = new EmailNotifierCreator(NotifyingData);
            NotifiableCreators.Add(EmailNotifierCreator);

            SlackNotifierCreator = new SlackNotifierCreator(NotifyingData);
            NotifiableCreators.Add(SlackNotifierCreator);

            SoundNotifierCreator = new SoundNotifierCreator(NotifyingData);
            NotifiableCreators.Add(SoundNotifierCreator);

            List<Notifier> notifierList = new List<Notifier>();
            foreach (var creator in NotifiableCreators)
                NotifierList.Add(creator.Create());
        }

        public void Run()
        {
            Console.WriteLine("=== 🧍 USER ACCOUNT CREATOR ===\n");
            int id = GetDataFromUser<int>("Enter id: ");
            string name = GetDataFromUser<string>("Enter name: ");

            Console.Write("Enter password: ");
            string password = ReadPassword();

            var newAccount = CreateAccount(id, name, password);
            var newUser = CreateUser(newAccount);

            newUser.DisplayInfo();

            AskForNotifiers(NotiferManager, NotifierList);

            NotiferManager.NotifyAll();
        }

        private Account CreateAccount(int id, string name, string password)
        {
            return new Account(id, name, password);
        }

        private UserType CreateUser(Account account)
        {
            return new UserType(account);
        }

        private void AskForNotifiers(NotiferManager notiferManager, List<Notifier> notifierList) {
            foreach (var notifier in notifierList)
            {
                var confirmation = AnsiConsole.Prompt(
                new TextPrompt<bool>($"Whould you like we send you notifications with {notifier.GetType().Name}: ")
                    .AddChoice(true)
                    .AddChoice(false)
                    .DefaultValue(true)
                    .WithConverter(choice => choice ? "y" : "n"));

                if (confirmation)
                    notiferManager.AddNotifier(notifier);
            }
        }

        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        private Type GetDataFromUser<Type>(string question) => AnsiConsole.Prompt(
                new TextPrompt<Type>(question));
    }
}
