
using System.Collections.Generic;
using Rosary.Domain;
using Rosary.Infrastructure.Database;

namespace Rosary.Infrastructure
{
    public class IntentionRepository
    {

        private static RosaryContext _context = new RosaryContext();

        public void Add(Intention intention)
        {
            _context.Database.EnsureCreated();
            _context.Intentions.Add(intention);
            _context.SaveChanges();
        }

        public List<Intention> Intentions { get; } = new List<Intention>
        {
            new Intention("intencja 1"),
            new Intention("intencja 2"),
            new Intention("intencja 3"),
            new Intention("intencja 4")
        };
    }
}