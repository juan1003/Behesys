var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Map Patients API endpoints
app.MapControllers();

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
