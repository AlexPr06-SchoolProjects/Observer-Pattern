using Observer_Pattern.Notifiers;

namespace Observer_Pattern.Factories.NotifierFactory
{
    internal abstract class NotifiableCreator
    {
        abstract public Notifier Create();
    }


    // Fabric method
    internal class NotifierCreator : NotifiableCreator
    {
        public override Notifier Create() => new Notifier();
    }
}
