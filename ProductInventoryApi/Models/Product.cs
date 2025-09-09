using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Models
{
    public class Product
    {
        public int Id { get; set; }  // Primary key

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is invalid or must be between 0 and 1,000,000.")]
        [Range(0, 1_000_000, ErrorMessage = "Price must be between 0 and 1,000,000.")]
        public decimal Price { get; set; }

        [Range(0, 1_000_000, ErrorMessage = "StockQuantity must be between 0 and 1,000,000.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(100, ErrorMessage = "Category must not exceed 100 characters.")]
        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;  // Soft delete flag
    }
}
