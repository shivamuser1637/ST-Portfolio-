var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("PortfolioDev", policy =>
    policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()));

var app = builder.Build();
app.UseCors("PortfolioDev");

app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));

app.MapPost("/api/contact", (ContactRequest request, ILogger<Program> logger) =>
{
    var name = request.Name?.Trim();
    var email = request.Email?.Trim();
    var message = request.Message?.Trim();
    if (string.IsNullOrWhiteSpace(name) || name.Length > 100 ||
        string.IsNullOrWhiteSpace(email) || email.Length > 200 ||
        !email.Contains('@') ||
        string.IsNullOrWhiteSpace(message) || message.Length > 2000)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["contact"] = ["Enter a name, valid email address, and message within the length limits."]
        });
    }

    // Demo behavior: log to the local API console. Connect a mail provider before deployment.
    logger.LogInformation("Portfolio contact from {Name} ({Email}): {Message}", name, email, message);
    return Results.Accepted(value: new { received = true });
});

app.Run();

internal sealed record ContactRequest(string? Name, string? Email, string? Message);
