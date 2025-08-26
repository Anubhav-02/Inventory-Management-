using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Dtos;

public class CreateProductDto
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [StringLength(1000)]
    public string? Description { get; set; }
    [Range(0, 1_000_000)]
    public decimal Price { get; set; }
    [Range(0, 1_000_000)]
    public int StockQuantity { get; set; }
    [Required, StringLength(100)]
    public string Category { get; set; } = string.Empty;
}
