using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Dtos; // Namespace for Data Transfer Objects

public class CreateProductDto // DTO for creating a new product
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;  // Product name
    [StringLength(1000)]
    public string? Description { get; set; }  // Optional product description
    [Range(0, 1_000_000)]
    public decimal Price { get; set; }  // Product price
    [Range(0, 1_000_000)]
    public int StockQuantity { get; set; }  // Quantity in stock
    [Required, StringLength(100)]
    public string Category { get; set; } = string.Empty;  // Product category
}
