using Observer_Pattern.Notifiers;

namespace Observer_Pattern.Managers
{
    internal class NotiferManager
    {
        private event NotificationHandler? _notificationHandler;

        public NotiferManager() { }

        public void AddNotifier(Notifier notifier)
        {
            _notificationHandler += notifier.Notify;
        }

        public void RemoveNotifer(Notifier notifier)
        {
            _notificationHandler -= notifier.Notify;
        }
        public void NotifyAll()
        {
            _notificationHandler?.Invoke();
        }
    }

    delegate void NotificationHandler();
}
