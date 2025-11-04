using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class ConsoleNotifier : Notifier
    {
        public ConsoleNotifier(NotifiableData notifiableData) : base(notifiableData) { }

        public override void Notify()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"🖥️ Console: {_notifiableData.Message}");
            Console.ResetColor();
        }
    }
}
