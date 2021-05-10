using System;

namespace OrareProMe.Domain
{
    public class Prayer
    {
        public Guid Id { get; set; }
        public Rosary Rosary { get; set; }

        public Guid RosaryId { get; set; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        private User Owner { get; set; }

        private Guid UserId { get; set; }



    }
}