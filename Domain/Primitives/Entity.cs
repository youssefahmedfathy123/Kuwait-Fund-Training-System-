using System;

namespace Domain.Primitives
{
    public abstract class Entity<T> : IEquatable<Entity<T>>
    {
        public T Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(T id)
        {
            Id = id;
        }

        public bool Equals(Entity<T>? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (other.GetType() != GetType())
                return false;

            return EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity<T>);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Entity<T>? left, Entity<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<T>? left, Entity<T>? right)
        {
            return !Equals(left, right);
        }
    }
}
