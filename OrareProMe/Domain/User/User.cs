using System;
using System.Collections.Generic;

namespace OrareProMe.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }

        public Role Role { get; set; }

        private string Password { get; set; }

        public virtual List<Intention> Intentions { get; set; }

    }
}