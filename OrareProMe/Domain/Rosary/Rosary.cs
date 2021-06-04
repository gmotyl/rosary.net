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
        public List<Mystery> LockedMysteries { get; } = new List<Mystery>();

        public Rosary()
        {
            foreach (Mystery mystery in (Mystery[])Enum.GetValues(typeof(Mystery)))
            {
                FreeMysteries.Add(mystery);
            }
        }

        public Mystery NextMystery()
        {
            var mystery = FreeMysteries.ElementAt(0);

            if (mystery != Mystery.Empty)
            {
                FreeMysteries.RemoveAt(0);
                LockedMysteries.Add(mystery);
            }

            return mystery;
        }
    }
}