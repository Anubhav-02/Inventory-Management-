using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Data;
using ProductInventoryApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// DB (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Custom Validation Error Response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .Select(e => new
            {
                Errors = e.Value!.Errors.Select(err =>
                    string.IsNullOrWhiteSpace(err.ErrorMessage)
                        ? "Invalid input."
                        : err.ErrorMessage
                ).ToArray()
            });

        var response = new
        {
            success = false,
            message = "Validation failed. Please correct the errors.",
            errors
        };

        return new BadRequestObjectResult(response);
    };
});


// Build and run the app
var app = builder.Build();

// Ensure DB exists
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>(); // global error handler

app.MapControllers();
app.Run();
