namespace Bet.Extensions.Walmart.Models.Items.Queries;

public class ItemsQuery
{
    /// <summary>
    /// Default: "*"
    /// Used for pagination when more than 200 items are retrieved.
    /// 'nextCursor' value received in response will be same for all subsequent page requests.
    /// </summary>
    [JsonPropertyName("nextCursor")]
    public string NextCursor { get; set; } = "*";

    /// <summary>
    /// An arbitrary alphanumeric unique ID, specified by the seller, which identifies each item.
    /// This will be used by the seller in the XSD file to refer to each item.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// Default: "0"
    /// The object response to start with, where 0 is the first entity that can be requested.
    /// It can only be used when includeDetails is set to true.
    /// </summary>
    [JsonPropertyName("offset")]
    public string? Offset { get; set; }

    /// <summary>
    /// Default: "20"
    /// The number of entities to be returned.It cannot be more than 50 entities.
    /// Use it only when the includeDetails is set to true.
    /// </summary>
    [JsonPropertyName("limit")]
    public string? Limit { get; set; }


    /// <summary>
    /// The lifecycle status of an item describes where the item listing is in the overall lifecycle.
    ///
    /// Examples of allowed values are ACTIVE , ARCHIVED, RETIRED.
    /// </summary>
    [JsonPropertyName("lifecycleStatus")]
    public string? LifecycleStatus { get; set; }


    /// <summary>
    /// The published status of an item describes where the item is in the submission process.
    ///
    /// Examples of allowed values are PUBLISHED, UNPUBLISHED.
    /// </summary>
    [JsonPropertyName("publishedStatus")]
    public string? PublishedStatus { get; set; }
}


