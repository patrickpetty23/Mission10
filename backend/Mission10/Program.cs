using Microsoft.EntityFrameworkCore;
using Mission10.Data;

// Create a new instance of WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add API explorer services
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation services
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors();

// Add DbContext service for BowlerContext
builder.Services.AddDbContext<BowlerContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:BowlingLeagueConnection"])
);

// Add scoped service for IBowlerRepository with EFBowlerRepository implementation
builder.Services.AddScoped<IBowlerRepository, EFBowlerRepository>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure CORS
app.UseCors(p => p.WithOrigins("http://localhost3000"));

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

// Run the application
app.Run();
