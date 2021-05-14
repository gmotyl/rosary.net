using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary
    {
        [Key]
        public long Id { get; set; }
        public Guid ExternalId { get; set; }

        public virtual Intention Intention { get; set; }

        public virtual List<Prayer> Prayers { get; set; }

        public Rosary()
        {
        }
    }
}