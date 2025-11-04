using Spectre.Console;



Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== 🧍 USER ACCOUNT CREATOR ===\n");



// User Creation 

int id = AnsiConsole.Prompt(
    new TextPrompt<int>("Enter user ID: "));

string? name = AnsiConsole.Prompt(
    new TextPrompt<string>("Enter name: "));

Console.Write("Enter password: ");
string? password = ReadPassword();

Account account = new Account(id, name, password);
User user = new User(account);

user.DisplayInfo();

// Notifyinh data
string notifyingDataMessage = "Hi, we are notifying you!";

NotifiableData notifyingData = new NotifiableData(notifyingDataMessage);

// Creatprs
List<NotifiableCreator> notifiableCreators = new List<NotifiableCreator>();

TelegramNotifierCreator telegramNotifierCreator = new TelegramNotifierCreator(notifyingData);
notifiableCreators.Add(telegramNotifierCreator);

SMSNotifierCreator sMSNotifierCreator = new SMSNotifierCreator(notifyingData);
notifiableCreators.Add(sMSNotifierCreator);

EmailNotifierCreator emailNotifierCreator = new EmailNotifierCreator(notifyingData);
notifiableCreators.Add(emailNotifierCreator);

SlackNotifierCreator slackNotifierCreator = new SlackNotifierCreator(notifyingData);
notifiableCreators.Add(slackNotifierCreator);

SoundNotifierCreator soundNotifierCreator = new SoundNotifierCreator(notifyingData);
notifiableCreators.Add(soundNotifierCreator);

List<Notifier> notifierList = new List<Notifier>();
foreach (var creator in notifiableCreators)
    notifierList.Add(creator.Create());


NotiferManager notiferManager = new NotiferManager();
foreach (var notifier in notifierList)
{
    var confirmation = AnsiConsole.Prompt(
    new TextPrompt<bool>($"Whould you like we send you notifications with {notifier}: ")
        .AddChoice(true)
        .AddChoice(false)
        .DefaultValue(true)
        .WithConverter(choice => choice ? "y" : "n"));

    if (confirmation)
        notiferManager.AddNotifier(notifier);
}

notiferManager.NotifyAll();







//Notifier telegramNotifier = new TelegramNotifier(notifyingData);
//Notifier



static string ReadPassword()
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



class Account
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }

    public Account(int id, string? name, string? password)
    {
        Id = id;
        Name = name;
        Password = password;
    }
}


class User {
    private Account _userAccount { get; set; }

    public User(Account userAccount)
    {
        _userAccount = userAccount;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\n✅ Account created successfully!");
        Console.WriteLine($"🆔 ID: {_userAccount.Id}");
        Console.WriteLine($"👤 Name: {_userAccount.Name}");
    }
}


class UserNotifer {
    private User _user { get; set; }
    public UserNotifer(User user)
    {
        _user = user;
    }
}















delegate void NotificationHandler();

struct NotifiableData {
    public string Message { get; set; }
    public NotifiableData(string message)
    {
        Message = message;
    }
}














abstract class NotifiableCreator
{
    abstract public Notifier Create();
}


// Fabric method
class NotifierCreator : NotifiableCreator
{
    public override Notifier Create() => new Notifier();
}

class TelegramNotifierCreator : NotifierCreator
{
    private NotifiableData _notifiableData;
    public TelegramNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new TelegramNotifier(_notifiableData);
}


class SMSNotifierCreator : NotifierCreator
{
    private NotifiableData _notifiableData;
    public SMSNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new SMSNotifier(_notifiableData);
}


class EmailNotifierCreator : NotifierCreator {
    private NotifiableData _notifiableData;
    public EmailNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new EmailNotifier(_notifiableData);
}


class SlackNotifierCreator : NotifierCreator
{
    private NotifiableData _notifiableData;
    public SlackNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new SlackNotifier(_notifiableData);
}

class ConsoleNotifierCreator : NotifierCreator
{
    private NotifiableData _notifiableData;
    public ConsoleNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new ConsoleNotifier(_notifiableData);
}

class SoundNotifierCreator : NotifierCreator
{
    private NotifiableData _notifiableData;
    public SoundNotifierCreator(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }
    public override Notifier Create() => new SoundNotifier(_notifiableData);
}










class NotiferManager
{
    private event NotificationHandler? _notificationHandler;

    public NotiferManager() {}

    public void AddNotifier(Notifier notifier)
    {
        _notificationHandler += notifier.Notify;
    }

    public void RemoveNotifer(Notifier notifier)
    {
        _notificationHandler -= notifier.Notify;
    }
    public void NotifyAll()
    {
        _notificationHandler?.Invoke();
    }
}

interface INotifiable
{
    void Notify();
}

class Notifier : INotifiable
{
    public NotifiableData _notifiableData { get; set; }

    public Notifier() { }

    public Notifier(NotifiableData notifiableData)
    {
        _notifiableData = notifiableData;
    }

    public virtual void Notify() { }
}

// 📨 Telegram notifier
class TelegramNotifier : Notifier
{
    public TelegramNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"📨 Telegram: {_notifiableData.Message}");
        Console.ResetColor();
    }
}

// 📱 SMS notifier
class SMSNotifier : Notifier
{
    public SMSNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"📱 SMS: {_notifiableData.Message}");
        Console.ResetColor();
    }
}

// 📧 Email notifier
class EmailNotifier : Notifier
{
    public EmailNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"📧 Email: {_notifiableData.Message}");
        Console.ResetColor();
    }
}

// 💬 Slack notifier
class SlackNotifier : Notifier
{
    public SlackNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"💬 Slack: {_notifiableData.Message}");
        Console.ResetColor();
    }
}

// ⚙️ Console notifier (useful for debugging or fallback)
class ConsoleNotifier : Notifier
{
    public ConsoleNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"🖥️ Console: {_notifiableData.Message}");
        Console.ResetColor();
    }
}

// 🔔 System sound notifier (mock)
class SoundNotifier : Notifier
{
    public SoundNotifier(NotifiableData notifiableData) : base(notifiableData) { }

    public override void Notify()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Beep();
        Console.WriteLine($"🔔 Sound alert: {_notifiableData.Message}");
        Console.ResetColor();
    }
}
