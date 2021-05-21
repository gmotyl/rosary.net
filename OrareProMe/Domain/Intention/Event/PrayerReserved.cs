namespace OrareProMe.Domain
{
    public class PrayerReserved : IDomainEvent
    {
        public long IntentionAgregateId { get; }
        public long RosaryId { get; }
        public long UserId { get; }
        public long PrayerId { get; }
        public PrayerReserved(long intentionAgregateId, long rosaryId, long userId, long prayerId)
        {
            IntentionAgregateId = intentionAgregateId;
            RosaryId = rosaryId;
            UserId = userId;
            PrayerId = prayerId;
        }
    }
}