using Bet.Extensions.Walmart.Models.Orders;
using Bet.Extensions.Walmart.Models.Orders.Queries;

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
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<Order> ListAllAsync(OrderQuery query, CancellationToken cancellationToken);
}
