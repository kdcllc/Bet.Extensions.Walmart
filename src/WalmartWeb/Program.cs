using System.Text.Json;

using Bet.Extensions.Walmart.Models.Notifications.Webhook;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(x =>
    {
        x.AddConsole();
        x.AddDebug();
    });

// builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapControllers();

var logger = app.Logger;

app.MapGet("/webhooks", () =>
{
    return Results.Ok();
});

app.MapPost("/webhooks", async (Event @event) =>
{
    // logger.LogInformation(@event.Source.EventType);

    var json = JsonSerializer.Serialize(@event);

    logger.LogInformation(json);
});

app.Run();
