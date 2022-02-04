namespace Bet.AspNetCore.Walmart.WebhookEvents;

public class WebhookEventResult
{
    public WebhookEventResult(Exception? exception = null)
    {
        Exception = exception;
    }

    /// <summary>
    /// Gets an <see cref="Exception"/> representing the exception that was thrown when checking for status (if any).
    /// </summary>
    public Exception? Exception { get; }
}
