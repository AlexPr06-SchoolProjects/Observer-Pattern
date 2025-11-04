namespace Observer_Pattern.Notifiers.Data
{
    internal struct NotifiableData
    {
        public string Message { get; set; }
        public NotifiableData(string message)
        {
            Message = message;
        }
    }

}
