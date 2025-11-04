using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers.NotifierTypes
{
    internal class SlackNotifier : Notifier
    {
        public SlackNotifier(NotifiableData notifiableData) : base(notifiableData) { }

        public override void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"💬 Slack: {_notifiableData.Message}");
            Console.ResetColor();
        }
    }
}
