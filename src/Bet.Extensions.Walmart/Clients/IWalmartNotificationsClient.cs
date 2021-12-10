using Bet.Extensions.Walmart.Models.Notifications;

namespace Bet.Extensions.Walmart.Clients;

public interface IWalmartNotificationsClient
{
    /// <summary>
    /// This API is used to retrieve the details of all subscriptions created using "create subscription" API.
    ///
    /// <see href="https://developer.walmart.com/api/us/mp/notifications#operation/getAllSubscriptions"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SubscriptionEvent>?> ListAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    ///  This API provides the list of event types and resource names that you can subscribe to.
    ///  Notifications will be triggered only for the event types that you subscribe to using Create Subscription API .
    /// </para>
    /// <para>
    /// Event Types are workflow events that are triggered when status or conditions change.
    /// Some examples are an offer moving from published to unpublished status, an order getting auto-cancelled by Walmart,
    /// a buy box price/winner change, etc.
    /// </para>
    ///
    /// <para>
    /// Resource Names are functional API categories that group similar event types.
    /// Resource Names can be Item, Price, Orders, Inventory, etc.
    /// The permissions to subscribe to an Event Type is defined by Resource Name which is mapped to permissions in Delegated Access.</para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/notifications#operation/getEventTypes"/>.</para>
    ///
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SubscriptionEventType>> ListAllEventTypesAsync(CancellationToken cancellationToken);


    /// <summary>
    /// <para>
    /// This API is used to update the details of subscriptions. You can update event version, event URL, headers,
    /// authentication details of a subscription using this API.
    /// You can also disable/enable the subscription by changing the status from ACTIVE to INACTIVE or vice versa .
    /// </para>
    ///
    /// <para></para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/notifications#operation/updateSubscription"/>.</para>
    ///
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubscriptionEvent?> UpdateAsync(string subscriptionId, SubscriptionEvent subscription, CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    /// This API is used to create subscription for notification of an event by selecting an event type, event version, resource name,
    /// and providing event URL. One or more than one events can be subscribed for notifications in one subscription request.
    /// </para>
    ///
    /// <para>
    /// Use Get Event Types API to get the list of event type, event version and resource name available for subscribing.
    /// </para>
    ///
    /// <para>Configure an event URL to receive the notifications.</para>
    ///
    /// <para>
    /// URL Authentication Options If authMethod is BASIC_AUTH, while making notification request to endpointUrl,
    /// Walmart system will pass authentication header with key as authHeaderName and value as BASE64 encoding of userName and password.
    /// If authMethod is HMAC, while making notification request to endpointUrl,
    /// Walmart system will pass authentication header with key as authHeaderName and value as HMACSHA256 of complete response,
    /// using clientSecret as key. If authMethod is OAUTH, Walmart system will make POST call to authUrl
    /// to generate token with request body as "grant_type=client_credentials" and headers as :
    /// Authorization header with key as authHeaderName and value as BASE64 encoding of clientId and clientSecret
    /// "Accept" :"application/json; charset=UTF-8" "Content-type":"application/x-www-form-urlencoded; charset=ISO-8859-1"
    /// Custom headers provided in headers field , if provided authURL should return HTTPS status 200 and response
    /// should have access_token and expires_in field. While making notification request to endpointUrl,
    /// Walmart system will pass access_token in headers with authHeaderName as key and value as Bearer along
    /// with any other custom headers provided in headers field.
    /// </para>
    ///
    /// <para></para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/notifications#operation/createSubscription"/>.</para>
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubscriptionEvent?> CreateAsync(SubscriptionEvent subscription, CancellationToken cancellationToken);

    /// <summary>
    /// <para>This API is used to delete the subscription. Once deleted, the subscription cannot be retrieved.</para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/notifications#operation/deleteSubscription"/>.</para>
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DeleteSubscriptionEvent?> DeleteAsync(string subscriptionId, CancellationToken cancellationToken);

    /// <summary>
    /// <para>This API can be used to send a test notification to the destination URL with the sample payload.</para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/notifications#operation/testNotification"/>.</para>
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string?> TestAsync(SubscriptionEvent subscription, CancellationToken cancellationToken);
}
