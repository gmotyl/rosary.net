using System;
using Castle.Components.DictionaryAdapter;

namespace OrareProMe.Domain
{
    public abstract class Entity
    {
        public long Id { get; }
        public Guid ExternalId { get; }

        protected Entity()
        {
        }

        protected Entity(long id) : this()
        {
            Id = id;
            ExternalId = new Guid();
        }
    }
}