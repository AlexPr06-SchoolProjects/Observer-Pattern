using Observer_Pattern.Notifiers;
using Observer_Pattern.Notifiers.NotifierTypes;
using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Factories.NotifierFactory.NotifierCreatorTypes
{
    internal class EmailNotifierCreator : NotifierCreator
    {
        private NotifiableData _notifiableData;
        public EmailNotifierCreator(NotifiableData notifiableData)
        {
            _notifiableData = notifiableData;
        }
        public override Notifier Create() => new EmailNotifier(_notifiableData);
    }
}
