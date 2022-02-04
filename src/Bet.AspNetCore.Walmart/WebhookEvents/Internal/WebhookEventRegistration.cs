namespace Bet.AspNetCore.Walmart.WebhookEvents.Internal;

internal class WebhookEventRegistration
{
    private Func<IServiceProvider, object>? _handlerFactory;

    public WebhookEventRegistration(
        string eventName,
        Func<IServiceProvider, object> factory,
        Type handlerType,
        Type eventType)
    {
        EventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
        HandlerFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
        EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
    }

    public string EventName { get; }

    public Type HandlerType { get; }

    public Type EventType { get; }

    public Func<IServiceProvider, object>? HandlerFactory
    {
        get => _handlerFactory;
        set => _handlerFactory = value ?? throw new ArgumentNullException(nameof(value));
    }
}
