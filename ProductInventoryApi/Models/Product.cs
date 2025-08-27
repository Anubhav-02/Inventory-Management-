using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Models;  // Namespace for data models

public class Product  // Product entity representing an item in the inventory
{
    public int Id { get; set; }  // Primary key
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
    public bool IsActive { get; set; } = true;  // Soft delete flag
}
