using System;

namespace OrareProMe.Domain.Intention
{
    public class Prayer
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public virtual Rosary Rosary { get; set; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        public virtual User User { get; set; }
    }
}