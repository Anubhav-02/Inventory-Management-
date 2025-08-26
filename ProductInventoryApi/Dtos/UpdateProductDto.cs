using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApi.Dtos;

public class UpdateProductDto
{
    [StringLength(100)]
    public string? Name { get; set; }
    [StringLength(1000)]
    public string? Description { get; set; }
    [Range(0, 1_000_000)]
    public decimal? Price { get; set; }
    [Range(0, 1_000_000)]
    public int? StockQuantity { get; set; }
    [StringLength(100)]
    public string? Category { get; set; }
}
