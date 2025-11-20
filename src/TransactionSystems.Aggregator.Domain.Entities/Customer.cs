using TransactionSystems.Aggregator.Domain.Entities.Base;
using TransactionSystems.Aggregator.Domain.Models;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents a customer in the transaction aggregation system.
    /// This is the main aggregate root for customer-related data.
    /// </summary>
    public sealed class Customer : Aggregate<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
            : base(Guid.Empty)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            CreatedDate = DateTimeOffset.UtcNow;
            LastActivityDate = null;
            IsActive = true;
            PaymentMethods = [];
            DataSourceConnections = [];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the customer.</param>
        public Customer(Guid id)
            : base(id)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            CreatedDate = DateTimeOffset.UtcNow;
            LastActivityDate = null;
            IsActive = true;
            PaymentMethods = [];
            DataSourceConnections = [];
        }

        /// <summary>
        /// Gets the customer's first name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the customer's last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the customer's email address.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the customer's phone number.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTimeOffset CreatedDate { get; private set; }

        /// <summary>
        /// Gets the date and time of the customer's last activity.
        /// </summary>
        public DateTimeOffset? LastActivityDate { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the customer is active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the collection of payment methods associated with this customer.
        /// </summary>
        public List<PaymentMethod> PaymentMethods { get; private set; }

        /// <summary>
        /// Gets the collection of data source connections associated with this customer.
        /// </summary>
        public List<DataSourceConnection> DataSourceConnections { get; private set; }
    }
}
