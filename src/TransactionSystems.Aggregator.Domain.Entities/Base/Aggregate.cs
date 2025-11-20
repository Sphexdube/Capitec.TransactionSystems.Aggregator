namespace TransactionSystems.Aggregator.Domain.Entities.Base
{
    /// <summary>
    /// Base class for aggregate roots in the domain model.
    /// An aggregate is a cluster of domain objects that can be treated as a single unit.
    /// The aggregate root is the only member of the aggregate that outside objects are allowed to hold references to.
    /// </summary>
    /// <typeparam name="TKey">The type of the aggregate's identifier.</typeparam>
    public abstract class Aggregate<TKey> : Entity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aggregate{TKey}"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the aggregate root.</param>
        protected Aggregate(TKey id) : base(id)
        {
        }

        /// <summary>
        /// Gets the date and time when the aggregate was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Gets the date and time when the aggregate was last modified.
        /// </summary>
        public DateTimeOffset? ModifiedAt { get; protected set; }

        /// <summary>
        /// Gets or sets the concurrency token for optimistic concurrency control.
        /// </summary>
        public byte[]? RowVersion { get; protected set; }
    }
}
