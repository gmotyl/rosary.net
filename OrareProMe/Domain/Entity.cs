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

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return obj is Entity entity &&
                   Id == entity.Id &&
                   ExternalId.Equals(entity.ExternalId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ExternalId);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}