using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class SMSNotifier : Notifier
    {
        public SMSNotifier(NotifiableData notifiableData) : base(notifiableData) { }

        public override void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"📱 SMS: {_notifiableData.Message}");
            Console.ResetColor();
        }
    }
}
