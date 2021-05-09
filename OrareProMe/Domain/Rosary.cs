using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace OrareProMe.Domain
{
    public class Rosary
    {
        [Key]
        public Guid Id { get; set; }

        public Intention Intention { get; set; }

        private Prayer[] Prayers { get; set; }

    }
}