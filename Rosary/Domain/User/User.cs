using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Rosary.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        private string Password { get; set; }

        public List<Intention> Intentions { get; set; }

    }
}