using CommerceAI.Api.Endpoints;
using CommerceAI.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductEndpoints();

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
});

app.Run();