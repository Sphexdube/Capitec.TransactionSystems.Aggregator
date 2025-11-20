namespace TransactionSystems.Aggregator.Domain.Models
{
    /// <summary>
    /// Represents a key-value pair tag that can be attached to a transaction for categorization or metadata.
    /// This is a value object used for flexible tagging of transactions.
    /// </summary>
    public sealed class TransactionTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionTag"/> class.
        /// </summary>
        public TransactionTag()
        {
            Key = string.Empty;
            Value = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionTag"/> class with the specified key and value.
        /// </summary>
        /// <param name="key">The tag key.</param>
        /// <param name="value">The tag value.</param>
        public TransactionTag(string key, string value)
        {
            Key = key ?? string.Empty;
            Value = value ?? string.Empty;
        }

        /// <summary>
        /// Gets the tag key (e.g., "category", "location", "merchant_type").
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the tag value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not TransactionTag other)
            {
                return false;
            }

            return Key == other.Key && Value == other.Value;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Value);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Key}: {Value}";
        }
    }
}
