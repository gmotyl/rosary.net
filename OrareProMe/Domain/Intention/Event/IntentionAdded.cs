namespace OrareProMe.Domain
{
    public sealed class IntentionAdded : IDomainEvent
    {
        public long IntentionId { get; }
        public string Title { get; }
        public string Description { get; }
        public IntentionAdded(long intentionId, string title, string description)
        {
            IntentionId = intentionId;
            Title = title;
            Description = description;
        }
    }
}