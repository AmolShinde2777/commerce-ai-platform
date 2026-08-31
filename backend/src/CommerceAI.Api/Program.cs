using CommerceAI.Api.Endpoints;
using CommerceAI.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("Frontend");

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapProductEndpoints();
app.MapChatEndpoints();

// Health endpoint
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        Application = "CommerceAI API",
        Version = "v1",
        Status = "Running",
        Timestamp = DateTime.UtcNow
    });
})
.WithName("HealthCheck")
.WithSummary("Returns API health/status")
.WithTags("Health");

app.Run();