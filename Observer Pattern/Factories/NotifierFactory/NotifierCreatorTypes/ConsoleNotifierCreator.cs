using Observer_Pattern.Notifiers;
using Observer_Pattern.Notifiers.NotifierTypes;
using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Factories.NotifierFactory.NotifierCreatorTypes
{
    internal class ConsoleNotifierCreator : NotifierCreator
    {
        private NotifiableData _notifiableData;
        public ConsoleNotifierCreator(NotifiableData notifiableData)
        {
            _notifiableData = notifiableData;
        }
        public override Notifier Create() => new ConsoleNotifier(_notifiableData);
    }
}
