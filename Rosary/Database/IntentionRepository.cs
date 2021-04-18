
using System.Collections.Generic;
using Rosary.Domain;

namespace Rosary.Database
{
    public class IntentionRepository
    {
        public List<Intention> Intentions { get; } = new List<Intention>
        {
            new Intention(1, "intencja 1"),
            new Intention(2, "intencja 2"),
            new Intention(3, "intencja 3"),
            new Intention(4, "intencja 4")
        };
    }
}