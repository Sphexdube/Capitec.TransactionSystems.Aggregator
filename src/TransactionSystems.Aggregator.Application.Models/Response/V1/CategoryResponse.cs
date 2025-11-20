namespace TransactionSystems.Aggregator.Application.Models.Response.V1
{
    /// <summary>
    /// Response model representing a transaction category.
    /// </summary>
    public sealed class CategoryResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the icon identifier or URL.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the color code for UI display.
        /// </summary>
        public string ColorCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the parent category identifier.
        /// </summary>
        public Guid? ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent category name.
        /// </summary>
        public string? ParentCategoryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a system-defined category.
        /// </summary>
        public bool IsSystemCategory { get; set; }

        /// <summary>
        /// Gets or sets the collection of subcategories.
        /// </summary>
        public List<CategoryResponse> SubCategories { get; set; } = [];
    }
}
