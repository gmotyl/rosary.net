namespace OrareProMe.Domain
{
    public sealed class IntentionAdded : IDomainEvent
    {
        public long IntentionId { get; }
        public string Title { get; }
        public IntentionAdded(long intentionId, string title)
        {
            IntentionId = intentionId;
            Title = title;
        }
    }
}