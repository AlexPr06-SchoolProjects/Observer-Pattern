using Observer_Pattern.Interfaces;
using Observer_Pattern.Notifiers.Data;

namespace Observer_Pattern.Notifiers
{
    internal class Notifier : INotifiable
    {
        public NotifiableData _notifiableData { get; set; }

        public Notifier() { }

        public Notifier(NotifiableData notifiableData)
        {
            _notifiableData = notifiableData;
        }

        public virtual void Notify() { }
    }

}
