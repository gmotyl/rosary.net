using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rosary.Domain
{
    public class Intention
    {

        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        private List<Rosary> Rosaries;

        public Intention()
        {
            this.Title = "title";
        }

        public Intention(string Title)
        {
            this.Title = Title;
        }
    }
}