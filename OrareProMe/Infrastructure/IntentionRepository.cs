
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrareProMe.Domain;
using OrareProMe.Infrastructure.Database;

namespace OrareProMe.Infrastructure
{
    public class IntentionRepository
    {

        private IApplicationDbContext _context;

        public IntentionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Intention intention)
        {
            // _context.Database.EnsureCreated();
            _context.Intentions.Add(intention);
            _context.SaveChanges();
        }

        public Intention GetById(Guid intentionId)
        {
            return _context.Intentions.Find(intentionId);
        }


        public List<Rosary> GetRosariesByIntentionId(Guid intentionId)
        {
            return _context.Rosaries.Where(r => r.Id == intentionId).ToList();
        }

        public void DeleteIntentionById(Guid intentionId)
        {
            var intention = this.GetById(intentionId);
            _context.Intentions.Remove(intention);
            _context.SaveChanges();
        }
    }
}