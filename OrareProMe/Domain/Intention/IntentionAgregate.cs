using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.Net.Http.Headers;
using OrareProMe.Domain.Specification;

namespace OrareProMe.Domain.Intention
{
    public class IntentionAgregate
    {

        [Key]
        public long Id { get; private set; }
        public Guid ExternalId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public virtual List<Rosary> Rosaries { get; private set; } = new List<Rosary>();

        public virtual User Owner { get; private set; }

        public IntentionAgregate()
        {
        }

        public IntentionAgregate(string title, string description, User owner)
        {
            this.Title = title;
            this.Description = description;
            this.Owner = owner;

            if (this.Rosaries.Count == 0)
            {
                this.Rosaries.Add(new Rosary());
            }
        }

        public Prayer ReservePrayer()
        {
            var rosarySpec = new RosaryHasAviablePrayers();
            var rosary = Rosaries.First(rosarySpec.IsSatisfiedBy);

            return rosary.NextPrayer();
        }
    }
}