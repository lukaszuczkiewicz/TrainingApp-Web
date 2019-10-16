using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.SharedKernel
{
    /// <summary>
    ///    Source: https://enterprisecraftsmanship.com/posts/entity-base-class/
    /// </summary>

    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        //public ICollection<IEvent> events { get; private set; }

        //protected void ApplyEvent(IEvent @event) // @ => just because evet is C# key word
        //{
        //    events.Add(@event);
        //}

        public virtual Guid Id { get; protected set; }
        protected virtual object Actual => this;

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Id == null || other.Id == null)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}
