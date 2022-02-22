using System.Text.Json;

namespace Bet.Extensions.Walmart.Services.Impl;

public class WebhookSerializer<TEntity> : IWebhookSerializer<TEntity> where TEntity : class
{
    public ValueTask<TEntity?> GetEventAsync(Stream stream, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.DeserializeAsync<TEntity>(stream, options, cancellationToken);
    }

    public TEntity? GetEvent(string json, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<TEntity>(json, options);
    }
}

