using System;

namespace OrareProMe.Domain
{
    public class Prayer
    {
        public Guid Id { get; set; }
        public Rosary Rosary { get; set; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        private User Owner { get; set; }

    }
}