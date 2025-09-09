using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Dtos
{
    public class CreateProductDto // DTO for creating a new product
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Error in Price.")]
        [Range(0, 1_000_000, ErrorMessage = "Price must be between 0 and 1,000,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Error in StockQuantity.")]
        [Range(0, 1_000_000, ErrorMessage = "StockQuantity must be between 0 and 1,000,000.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(100, ErrorMessage = "Category must not exceed 100 characters.")]
        public string Category { get; set; } = string.Empty;
    }
}
