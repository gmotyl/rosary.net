using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace OrareProMe.Domain
{
    public class User
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        private string Password { get; set; }

        public virtual List<Intention> Intentions { get; set; }

    }
}