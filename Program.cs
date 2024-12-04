using locationApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<LocationRepository>();
builder.Services.AddDbContext<LocationsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "location API"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
