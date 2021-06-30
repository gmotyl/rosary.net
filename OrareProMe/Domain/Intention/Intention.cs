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

        public Prayer ReservePrayer(long userId, Func<DateTime> utcTimeNow)
        {
            return _getReservedPrayer(userId, (Rosary rosary) => rosary.NextMystery(utcTimeNow));
        }

        public Prayer ReservePrayer(long userId)
        {
            return _getReservedPrayer(userId, (Rosary rosary) => rosary.NextMystery());
        }

        private Prayer _getReservedPrayer(long userId, Func<Rosary, Mystery> getNextMystery)
        {
            Prayer prayer;
            var hasFreeMystery = new RosaryHasAviablePrayers();
            var hasExpiredMystery = new RosaryHasExpiredMysteries();
            var rosarySpec = hasFreeMystery.Or(hasExpiredMystery);
            var rosary = Rosaries.First(rosarySpec.IsSatisfiedBy);
            var mystery = getNextMystery(rosary);

            if (Mystery.Empty == mystery)
            {
                Rosary nextRosary = new Rosary();
                this.Rosaries.Add(nextRosary);
                Mystery nextMystery = getNextMystery(nextRosary);
                prayer = new Prayer(nextRosary, nextMystery);
                RaiseDomainEvent(new PrayerReserved(Id, nextMystery, userId, prayer.Id));
            }
            else
            {
                prayer = new Prayer(rosary, mystery);
                RaiseDomainEvent(new PrayerReserved(Id, mystery, userId, prayer.Id));
            }

            return prayer;
        }
    }
}