namespace OrareProMe.Domain
{
    public sealed class PrayerReserved : IDomainEvent
    {
        public long IntentionId { get; }
        public Mystery MysteryReserved { get; }
        public long UserId { get; }
        public long PrayerId { get; }
        public PrayerReserved(long intentionId, Mystery mystery, long userId, long prayerId)
        {
            IntentionId = intentionId;
            MysteryReserved = mystery;
            UserId = userId;
            PrayerId = prayerId;
        }
    }
}