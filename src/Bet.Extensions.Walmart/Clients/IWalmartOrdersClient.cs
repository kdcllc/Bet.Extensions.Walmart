using Bet.Extensions.Walmart.Models.Orders;
using Bet.Extensions.Walmart.Models.Orders.Cancel;
using Bet.Extensions.Walmart.Models.Orders.Queries;
using Bet.Extensions.Walmart.Models.Orders.Refunds;
using Bet.Extensions.Walmart.Models.Orders.Ship;

namespace Bet.Extensions.Walmart.Clients;

public interface IWalmartOrdersClient
{
    /// <summary>
    /// <para>Retrieves the details of all the orders for specified search criteria.</para>
    /// <para>
    ///     Only orders created in last 180 days and a maximum of 20000 orders can be fetched at a time.
    ///     Attempting to download more than 20000 orders will return an error.
    /// </para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/getAllOrders"/>.</para>
    ///
    /// </summary>
    /// <param name="query">The <see cref="OrderQuery"/>, null parameters are not added to the query string.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns></returns>
    IAsyncEnumerable<Order> ListAllAsync(OrderQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    ///  Retrieves all the orders with line items that are in the "created" status,
    ///  that is, these orders have been released from the Walmart Order Management System to the seller for processing.
    ///  The released orders are the orders that are ready for a seller to fulfill.
    /// </para>
    ///
    /// <para>Only orders created in last 180 days and a maximum of 20000 orders can be fetched at a time. Attempting to download more than 20000 orders will return an error.</para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/getAllReleasedOrders"/>.</para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<Order> ListAllReleasedAsync(OrderQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    ///     You can use this API to acknowledge an entire order, including all of its order lines.
    ///     Walmart requires a seller to acknowledge orders within four hours of receipt of the order, except in extenuating circumstances.
    /// </para>
    ///
    /// <para>The response to a successful call contains the acknowledged order.</para>
    ///
    /// <para>
    ///     In general, only orders that are in a Created state should be acknowledged.
    ///     As a good practice, acknowledge your orders to avoid underselling.
    ///     Orders that are in an Acknowledged state can be re-acknowledged,
    ///     possibly in response to an error response from an earlier call to acknowledge order.
    ///     Orders with line items that are shipped or canceled should not be re-acknowledged.
    /// </para>
    ///
    /// <para><see href="https://developer.walmart.com/api/ca/mp/orders#operation/acknowledgeOrders"/>.</para>
    /// </summary>
    /// <param name="purchaseOrderId">The Walmart assigned PurchaseOrderId.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns></returns>
    Task<Order?> AcknowledgeAsync(string purchaseOrderId, CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    ///  Updates the status of order lines to Shipped and trigger the charge to the customer.
    ///  You must acknowledge your orders before sending a shipping update to avoid underselling.
    ///  After canceling your order, update the inventory for the canceled order and send it in the next inventory feed.
    ///  An order line, once marked as shipped, cannot be updated.
    ///  </para>
    ///
    /// <para>*NOTE: shipDateTime must be in UTC. *.</para>
    ///
    /// <para>The response to a successful call contains the order with the shipped line item.</para>
    ///
    /// <para></para>
    ///
    /// <para><see href="https://developer.walmart.com/api/ca/mp/orders#operation/shippingUpdates"/>.</para>
    /// </summary>
    /// <param name="purchaseOrderId">The Walmart assigned PurchaseOrderId.</param>
    /// <param name="orderShipment"><see cref="OrderShipment"/> details.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns></returns>
    Task<Order?> ShipAsync(string purchaseOrderId, OrderShipment orderShipment, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Retrieves an order detail for a specific purchaseOrderId.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/getAnOrder"/>.</para>
    /// </summary>
    /// <param name="purchaseOrderId">The Walmart assigned PurchaseOrderId.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns></returns>
    Task<Order?> GetAsync(string purchaseOrderId, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Retrieves an order detail for a specific purchaseOrderId with extra search critiria.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/getAnOrder"/>.</para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Order?> GetAsync(SingleOrderQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// <para>
    ///    You can cancel one or more order lines. You must include a purchaseOrderId when cancelling an order line.
    ///    The response to a successful call contains the order with the cancelled line items.
    /// </para>
    ///
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/cancelOrderLines"/>.</para>
    /// </summary>
    /// <param name="purchaseOrderId">The Walmart assigned PurchaseOrderId.</param>
    /// <param name="orderCancellation"><see cref="OrderCancellation"/>.</param>
    /// <param name="cancellationToken">The Cancellation Token.</param>
    /// <returns></returns>
    Task<Order?> CancelAsync(string purchaseOrderId, OrderCancellation orderCancellation, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Refunds one or more order lines that have been shipped. The response to a successful call contains the order with the refunded line items.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/orders#operation/refundOrderLines"/>.</para>
    /// </summary>
    /// <param name="orderRefund"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Order?> RefundAsync(OrderRefund orderRefund, CancellationToken cancellationToken);
}
