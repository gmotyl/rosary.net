using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.Net.Http.Headers;

namespace OrareProMe.Domain
{
    public class Intention : AggregateRoot
    {

        public string Title { get; private set; }

        public string Description { get; private set; }

        public virtual List<Rosary> Rosaries { get; private set; } = new List<Rosary>();

        public virtual User Owner { get; private set; }

        public Intention(string title, string description, User owner)
        {
            this.Title = title;
            this.Description = description;
            this.Owner = owner;

            if (this.Rosaries.Count == 0)
            {
                this.Rosaries.Add(new Rosary());
            }

            RaiseDomainEvent(new IntentionAdded(Id, title, description));
        }

        public Prayer ReservePrayer(long userId)
        {
            var rosarySpec = new RosaryHasAviablePrayers();
            var rosary = Rosaries.First(rosarySpec.IsSatisfiedBy);
            var mystery = rosary.NextMystery();
            Prayer prayer = new Prayer();

            RaiseDomainEvent(new PrayerReserved(Id, mystery, userId, prayer.Id));

            return prayer;
        }
    }
}