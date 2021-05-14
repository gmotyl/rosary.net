using System;

namespace OrareProMe.Domain
{
    public class Prayer
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public Rosary Rosary { get; set; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        private User Owner { get; set; }

        private Guid UserId { get; set; }



    }
}