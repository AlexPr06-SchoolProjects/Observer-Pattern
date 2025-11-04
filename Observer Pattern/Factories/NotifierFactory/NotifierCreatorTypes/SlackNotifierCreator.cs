using Observer_Pattern.Notifiers;
using Observer_Pattern.Notifiers.NotifierTypes;
using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Factories.NotifierFactory.NotifierCreatorTypes
{
    internal class SlackNotifierCreator : NotifierCreator
    {
        private NotifiableData _notifiableData;
        public SlackNotifierCreator(NotifiableData notifiableData)
        {
            _notifiableData = notifiableData;
        }
        public override Notifier Create() => new SlackNotifier(_notifiableData);
    }
}
