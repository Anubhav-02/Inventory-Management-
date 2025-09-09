using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Data;
using ProductInventoryApi.Dtos;
using ProductInventoryApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventoryApi.Controllers;  // API controller for managing products

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;  // Database context
    public ProductsController(AppDbContext db) => _db = db;

    [HttpPost] // Create a new product
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        var product = new Product // Map DTO to entity
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            Category = dto.Category,
            IsActive = true
        };

        _db.Products.Add(product); // Add to DbContext
        await _db.SaveChangesAsync();  // Save to database

        
        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            new
            {
                message = "Product added successfully.",
                product
            }
        ); // Return 201 Created with product details
    }


    [HttpGet] // Get all products with filtering, sorting, and pagination
    public async Task<ActionResult<IEnumerable<Product>>> GetAll(
        [FromQuery] string? category,
        [FromQuery] string? sort,
        [FromQuery] string? search,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] bool? lowStock = null)
    {
        if (page < 1) page = 1;  // Ensure valid page number
        if (pageSize < 1) pageSize = 10;  // Ensure valid page size
        if (pageSize > 100) pageSize = 100;  // Cap page size to prevent excessive data

        // Base query: only active products
        IQueryable<Product> query = _db.Products.AsNoTracking().Where(p => p.IsActive);

        // Search by name or description or category
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(s) || (p.Description != null && p.Description.ToLower().Contains(s)) || p.Category.ToLower().Contains(s));
        }

        // Filter for low stock if specified
        if (lowStock == true)
            query = query.Where(p => p.StockQuantity <= 5);

        // Apply sorting
        query = sort switch
        {
            "price_asc" => query.OrderBy(p => (double)p.Price).ThenBy(p => p.Id),
            "price_desc" => query.OrderByDescending(p => (double)p.Price).ThenBy(p => p.Id),
            _ => query.OrderBy(p => p.Id)
        };

        // Get total count for pagination
        var total = await query.CountAsync();
        Response.Headers["X-Total-Count"] = total.ToString();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return Ok(items);
    }

    [HttpGet("{id:int}")] // Get a product by ID
    public async Task<IActionResult> GetById(int id)
    {
        // Find product by ID and ensure it's active
        var product = await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPut("{id:int}")] // Update an existing product
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
    {
        // Find product by ID and ensure it's active
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        if (product is null) return NotFound();
        if (dto.Name is not null) product.Name = dto.Name;
        if (dto.Description is not null) product.Description = dto.Description;
        if (dto.Price.HasValue) product.Price = dto.Price.Value;
        if (dto.StockQuantity.HasValue) product.StockQuantity = dto.StockQuantity.Value;
        if (dto.Category is not null) product.Category = dto.Category;
        await _db.SaveChangesAsync();
        return Ok(new
        {
            success = true,
            message = "Product updated successfully.",
            data = product
        });
    }

    [HttpDelete("{id:int}")] // Hard delete a product
    public async Task<IActionResult> HardDelete(int id)
    {
        // Find the product by ID
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return NotFound(new { message = "Product not found." });

        _db.Products.Remove(product); // Permanently remove from database
        await _db.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            message = "Product deleted permanently."
        });
    }

    [HttpDelete("search")] // Soft delete by search term
    public async Task<IActionResult> SoftDeleteBySearch([FromQuery] string search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return BadRequest(new { message = "Search term is required." });

        var s = search.Trim().ToLower();
        var products = await _db.Products
            .Where(p => p.IsActive &&
                        (p.Name.ToLower().Contains(s) ||
                         (p.Description != null && p.Description.ToLower().Contains(s)) ||
                         p.Category.ToLower().Contains(s)))
            .ToListAsync();

        if (!products.Any())
            return NotFound(new { message = "No active products found matching the search term." });

        foreach (var product in products)
        {
            product.IsActive = false;
        }

        await _db.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            message = $"{products.Count} product(s) deleted successfully.",
            deletedProducts = products.Select(p => new { p.Id, p.Name, p.Category })
        });
    }
}
