using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class TelegramNotifier : Notifier
    {
        public TelegramNotifier(NotifiableData notifiableData) : base(notifiableData) { }

        public override void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"📨 Telegram: {_notifiableData.Message}");
            Console.ResetColor();
        }
    }

}
