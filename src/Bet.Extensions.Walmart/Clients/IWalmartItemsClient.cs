using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Items;
using Bet.Extensions.Walmart.Models.Items.Queries;

namespace Bet.Extensions.Walmart.Clients;

/// <summary>
/// <para>Displays a list of all items by using either nextCursor or offset and limit query parameters.</para>
/// <para>This client represents <see href="https://developer.walmart.com/api/us/mp/items"/>.</para>
/// </summary>
public interface IWalmartItemsClient
{
    /// <summary>
    /// Returns a single set of items per specified limit.
    /// <para><see href="https://developer.walmart.com/api/us/mp/items#operation/getAllItems"/>.</para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Item>?> ListAsync(ItemQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Displays a list of all items by using either nextCursor or offset and limit query parameters.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/items#operation/getAllItems"/>.</para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<Item> ListAllAsync(ItemQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Retrieves an item and displays the item details.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/items#operation/getAnItem"/>.</para>
    /// </summary>
    /// <param name="id">
    ///     Represents the seller-specified unique ID for each item.
    ///
    ///     Takes SKU code by default. If you require more specific item codes, such as GTIN, UPC, ISBN, EAN, or ITEM_ID,
    ///     you need to use the productIdType query parameter and specify the desired code e.g. productIdType=GTIN.
    /// </param>
    /// <param name="productType">
    ///     Enum: "GTIN" "UPC" "ISBN" "EAN" "SKU" "ITEM_ID"
    ///     Item code type specifier allows to filter by specific code type, (e.g.GTIN).
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Item?> GetAsync(string id, ProductTypeEnum productType, CancellationToken cancellationToken);

    /// <summary>
    /// <para>Retrieves an item and displays the item details.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/items#operation/getAnItem"/>.</para>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Item?> GetAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// <see href="https://developer.walmart.com/api/us/mp/items#operation/getTaxonomyResponse"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Taxonomy?> GetTaxonomyAsync(CancellationToken cancellationToken);

    /// <summary>
    /// <para>Completely deactivates and un-publishes an item from the site.</para>
    /// <para><see href="https://developer.walmart.com/api/us/mp/items#operation/retireAnItem"/>.</para>
    /// </summary>
    /// <param name="sku">
    /// An arbitrary alphanumeric unique ID, specified by the seller, which identifies each item.
    /// This will be used by the seller in the XSD file to refer to each item.
    /// Special characters in the sku needing encoding are:
    /// ':', '/', '?', '#', '[', ']', '@', '!', '$', '&', "'", '(', ')', '*', '+', ',', ';', '=', as well as '%' itself.
    /// Other characters don't need to be encoded.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(string sku, CancellationToken cancellationToken);


    /// <summary>
    /// <para>Get Item Associations API allows you to retrieve shippingTemplate and shipNode associated with the provided items.</para>
    /// <para>see href="https://developer.walmart.com/api/us/mp/items#operation/getItemAssociations"/>.</para>
    /// </summary>
    /// <param name="skus"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<ItemAssociations>?> GetItemAssociationsAsync(IList<string> skus, CancellationToken cancellationToken);
}
