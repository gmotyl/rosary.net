using System;

namespace OrareProMe.Domain
{
    public class LockedMystery : ValueObject<LockedMystery>
    {
        private readonly Func<DateTime> _utcTimeNow = () => DateTime.UtcNow;

        public Mystery Mystery {get;}
        private DateTime Date { get; set; }

        protected override bool EqualsCore(LockedMystery other)
        {
            return Mystery.Equals(other.Mystery);
        }
        public LockedMystery(Mystery mystery) 
        {
            Mystery = mystery;
            Date = _utcTimeNow();
        }
        
        public LockedMystery(Mystery mystery, Func<DateTime> utcTimeNow)
        {
            _utcTimeNow = utcTimeNow;
            Mystery = mystery;
            Date = _utcTimeNow();
        }

        public Boolean IsLocked()
        {

            var lockDate = Date.AddMinutes(10);
            var currentTime = _utcTimeNow();

            return lockDate > currentTime;
        }
    }
}