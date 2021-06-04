using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary : ValueObject<Rosary>
    {
        public List<Mystery> FinishedPrayers { get; } = new List<Mystery>();
        public List<Mystery> FreePrayers { get; } = new List<Mystery>();
        public List<Mystery> LockedPrayers { get; } = new List<Mystery>();

        public Rosary()
        {
            foreach (Mystery mystery in (Mystery[])Enum.GetValues(typeof(Mystery)))
            {
                FreePrayers.Add(mystery);
            }
        }

        public Mystery NextMystery()
        {
            var prayer = FreePrayers.ElementAt(0);
            FreePrayers.RemoveAt(0);
            LockedPrayers.Add(prayer);

            return prayer;
        }

        protected override bool EqualsCore(Rosary other)
        {
            return FinishedPrayers.SequenceEqual(other.FinishedPrayers)
                && FreePrayers.SequenceEqual(other.FreePrayers)
                && LockedPrayers.SequenceEqual(other.LockedPrayers);
        }
    }
}