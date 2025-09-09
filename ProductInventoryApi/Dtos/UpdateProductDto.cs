using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Dtos;

public class UpdateProductDto  // DTO for updating an existing product
{
    [StringLength(100)]
    public string? Name { get; set; }  // Optional product name

    [StringLength(1000)]
    public string? Description { get; set; }  // Optional product description

    [Range(0, 1_000_000)]
    public decimal? Price { get; set; }  // Optional product price

    [Range(0, 1_000_000)]
    public int? StockQuantity { get; set; }  // Optional quantity in stock

    [StringLength(100)]
    public string? Category { get; set; }  // Optional product category
}
