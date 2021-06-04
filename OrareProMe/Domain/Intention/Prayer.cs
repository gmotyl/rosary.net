using System;

namespace OrareProMe.Domain
{
    public class Prayer : Entity
    {
        public virtual Rosary Rosary { get; set; }

        public Mystery Mystery { get; }

        private DateTime Date { get; set; }

        private DateTime LockDate { get; set; }

        public virtual User User { get; set; }

        public Prayer(Rosary rosary, Mystery mystery)
        {
            Rosary = rosary;
            Mystery = mystery;
        }
    }
}