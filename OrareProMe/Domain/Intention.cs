using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace OrareProMe.Domain
{
    public class Intention
    {

        [Key]
        public long Id { get; private set; }
        public Guid ExternalId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public List<Rosary> Rosaries { get; private set; } = new List<Rosary>();

        public User Owner { get; private set; }

        public Intention()
        {
            this.Title = "title";
        }

        public Intention(string title, string description, User owner)
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
            return new Prayer();
        }
    }
}