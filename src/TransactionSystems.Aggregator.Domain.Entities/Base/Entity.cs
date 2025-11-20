namespace TransactionSystems.Aggregator.Domain.Entities.Base
{
    /// <summary>
    /// Base class for all entities in the domain model.
    /// An entity is an object that is defined by its identifier rather than its attributes.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
    public abstract class Entity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TKey}"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the entity.</param>
        protected Entity(TKey id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public TKey Id { get; protected set; }

        /// <summary>
        /// Determines whether the specified entity is equal to the current entity.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns>true if the specified entity is equal to the current entity; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TKey> other)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Returns the hash code for this entity.
        /// </summary>
        /// <returns>A hash code for the current entity.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether two entities are equal.
        /// </summary>
        /// <param name="left">The first entity to compare.</param>
        /// <param name="right">The second entity to compare.</param>
        /// <returns>true if the entities are equal; otherwise, false.</returns>
        public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two entities are not equal.
        /// </summary>
        /// <param name="left">The first entity to compare.</param>
        /// <param name="right">The second entity to compare.</param>
        /// <returns>true if the entities are not equal; otherwise, false.</returns>
        public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
        {
            return !(left == right);
        }
    }
}
