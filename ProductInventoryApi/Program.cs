using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Data;

var builder = WebApplication.CreateBuilder(args);

// --- DB (SQLite) ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Controllers ---
builder.Services.AddControllers();

// --- Swagger (always on) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure DB exists
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Swagger UI (enabled regardless of environment)
app.UseSwagger();
app.UseSwaggerUI();

// IMPORTANT: disable HTTPS redirection for local dev to avoid redirect warnings
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
