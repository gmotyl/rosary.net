using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary : Entity
    {
        public virtual Intention Intention { get; set; }

        public virtual List<Prayer> Prayers { get; set; }

        public Rosary()
        {
        }

        public Prayer NextPrayer()
        {
            var prayer = new Prayer();
            Prayers.Add(prayer);

            return prayer;
        }
    }
}