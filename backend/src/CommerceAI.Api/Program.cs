var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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