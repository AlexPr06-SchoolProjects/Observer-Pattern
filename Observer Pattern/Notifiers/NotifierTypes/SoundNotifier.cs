using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class SoundNotifier : Notifier
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
}
