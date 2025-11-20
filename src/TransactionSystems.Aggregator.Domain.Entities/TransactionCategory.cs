using TransactionSystems.Aggregator.Domain.Entities.Base;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents a category for organizing and classifying transactions.
    /// Supports hierarchical categorization with parent-child relationships.
    /// </summary>
    public sealed class TransactionCategory : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCategory"/> class.
        /// </summary>
        public TransactionCategory()
            : base(Guid.Empty)
        {
            Name = string.Empty;
            Description = string.Empty;
            Icon = string.Empty;
            ColorCode = string.Empty;
            ParentCategoryId = null;
            IsSystemCategory = false;
            SubCategories = [];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCategory"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the category.</param>
        public TransactionCategory(Guid id)
            : base(id)
        {
            Name = string.Empty;
            Description = string.Empty;
            Icon = string.Empty;
            ColorCode = string.Empty;
            ParentCategoryId = null;
            IsSystemCategory = false;
            SubCategories = [];
        }

        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the category.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the icon identifier or URL for visual representation.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// Gets the color code (e.g., hex color) for UI display.
        /// </summary>
        public string ColorCode { get; private set; }

        /// <summary>
        /// Gets the identifier of the parent category for hierarchical categorization.
        /// </summary>
        public Guid? ParentCategoryId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this is a system-defined category that cannot be modified.
        /// </summary>
        public bool IsSystemCategory { get; private set; }

        /// <summary>
        /// Gets the parent category if this is a subcategory.
        /// </summary>
        public TransactionCategory? ParentCategory { get; private set; }

        /// <summary>
        /// Gets the collection of subcategories under this category.
        /// </summary>
        public List<TransactionCategory> SubCategories { get; private set; }
    }
}
