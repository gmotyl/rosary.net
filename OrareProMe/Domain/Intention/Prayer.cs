using System;

namespace OrareProMe.Domain
{
    public class Prayer : Entity
    {
        public virtual Rosary Rosary { get; set; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        public virtual User User { get; set; }
    }
}