using System.Collections.Generic;

namespace Rosary.Domain
{
    public class Intention
    {
        public int _id { get; set; }

        public string Title { get; }

        public string Description { get; set; }

        private List<Rosary> _rosaries;

        public Intention(int Id, string Title)
        {
            _id = Id;
            this.Title = Title;
        }
    }
}