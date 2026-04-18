using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Finance Planning API");
    });
}

app.UseHttpsRedirection();

string name = "Димка";


app.MapGet("/healthcheck", () =>
    {
        var forecast = new Healthcheck(
            "Ты",
            true,
                name,
            DateOnly.FromDateTime(DateTime.Now)
            );
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record Healthcheck (string Who, bool IsTrue, string Name, DateOnly When)
{
    public DateOnly Until => When.AddDays(1);
}