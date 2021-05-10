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
        public Guid IntentionId { get; set; }

        private List<Prayer> Prayers { get; set; }

    }
}