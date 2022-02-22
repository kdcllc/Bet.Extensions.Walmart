using System.Text.Json;

using Bet.Extensions.Walmart.Models.Notifications.Webhook;

using WalmartWeb.EventHandlers;

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

builder.Services.AddWalmartWebhooksEvents((o, c) =>
{
    o.UserName = "username";
    o.Password = "password";
})
.AddWebhookEvent<POCreatedEventHandler, POCreatedEvent>(WebhookEvents.POCreated);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWalmartWebhookEvents();

// app.MapControllers();

var logger = app.Logger;

app.MapGet("/webhooks", () =>
{
    return Results.Ok();
});

app.MapPost("/webhooks", async (POCreatedEvent @event) =>
{
    // logger.LogInformation(@event.Source.EventType);

    var json = JsonSerializer.Serialize(@event);

    logger.LogInformation(json);
});

app.Run();
