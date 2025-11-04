using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class EmailNotifier : Notifier
    {
        public EmailNotifier(NotifiableData notifiableData) : base(notifiableData) { }

        public override void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"📧 Email: {_notifiableData.Message}");
            Console.ResetColor();
        }
    }
}
