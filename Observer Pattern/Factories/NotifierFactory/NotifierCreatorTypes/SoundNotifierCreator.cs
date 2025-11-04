using Observer_Pattern.Notifiers;
using Observer_Pattern.Notifiers.NotifierTypes;
using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Factories.NotifierFactory.NotifierCreatorTypes
{
    internal class SoundNotifierCreator : NotifierCreator
    {
        private NotifiableData _notifiableData;
        public SoundNotifierCreator(NotifiableData notifiableData)
        {
            _notifiableData = notifiableData;
        }
        public override Notifier Create() => new SoundNotifier(_notifiableData);
    }
}
