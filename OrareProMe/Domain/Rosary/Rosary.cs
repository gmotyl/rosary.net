using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary : AggregateRoot
    {
        public List<Mystery> FinishedMysteries { get; } = new List<Mystery>();
        public List<Mystery> FreeMysteries { get; } = new List<Mystery>();
        public List<LockedMystery> LockedMysteries { get; } = new List<LockedMystery>();

        public Rosary()
        {
            foreach (Mystery mystery in (Mystery[])Enum.GetValues(typeof(Mystery)))
            {
                FreeMysteries.Add(mystery);
            }
            LockedMysteries.Add(new LockedMystery(Mystery.Empty));
        }

        public void Finish(Mystery mystery)
        {
            FinishedMysteries.Add(mystery);
            FreeMysteries.Remove(mystery);
            LockedMysteries.RemoveAll(lm => lm.Mystery == mystery);
        }

        public Mystery NextMystery(Func<DateTime> utcTimeNow)
        {
            return _getNextMystery((m) => new LockedMystery(m, utcTimeNow));
        }

        public Mystery NextMystery()
        {
            return _getNextMystery((m) => new LockedMystery(m));
        }

        private Mystery _getNextMystery(Func<Mystery, LockedMystery> lockMystery)
        {
            var mystery = FreeMysteries.ElementAt(0);

            foreach (var lMystery in LockedMysteries)
            {
                if (!lMystery.IsLocked()) {
                    mystery = lMystery.Mystery;
                    LockedMysteries.Remove(lMystery);
                    break;
                }
            }

            if (mystery != Mystery.Empty)
            {
                FreeMysteries.Remove(mystery);
                LockedMysteries.Add(lockMystery(mystery));
            }

            return mystery;
        }


    }
}