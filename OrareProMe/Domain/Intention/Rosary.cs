using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using OrareProMe.Domain.Intention;

namespace OrareProMe.Domain.Intention
{
    public class Rosary
    {
        [Key]
        public long Id { get; set; }
        public Guid ExternalId { get; set; }

        public virtual IntentionAgregate Intention { get; set; }

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