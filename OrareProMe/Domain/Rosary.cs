using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary
    {
        [Key]
        public Guid Id { get; set; }

        public Intention Intention { get; set; }

        public List<Prayer> Prayers { get; set; }

        public Rosary()
        {
        }
    }
}