namespace OrareProMe.Domain
{
    public sealed class PrayerReserved : IDomainEvent
    {
        public long IntentionId { get; }
        public long RosaryId { get; }
        public long UserId { get; }
        public long PrayerId { get; }
        public PrayerReserved(long intentionId, long rosaryId, long userId, long prayerId)
        {
            IntentionId = intentionId;
            RosaryId = rosaryId;
            UserId = userId;
            PrayerId = prayerId;
        }
    }
}