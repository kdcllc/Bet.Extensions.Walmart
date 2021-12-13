namespace Bet.Extensions.Walmart.Models.Orders.Queries;

public class OrderQuery
{
    /// <summary>
    /// A seller-provided Product ID.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// The customer order ID.
    /// </summary>
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; set; }

    /// <summary>
    /// The purchase order ID. One customer may have multiple purchase orders.
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; set; }

    /// <summary>
    /// Status of purchase order line. Valid statuses are: Created, Acknowledged, Shipped, Delivered and Cancelled.
    /// </summary>

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Fetches all purchase orders that were created after this date.
    /// Default is current date - 7 days. Use either UTC or ISO 8601 formats.
    /// Date example: '2020-03-16'(yyyy-MM-dd). Date with Timestamp example: '2020-03-16T10:30:15Z'(yyyy-MM-dd'T'HH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("createdStartDate")]
    public DateTimeOffset? CreatedStartDate { get; set; }

    /// <summary>
    /// Fetches all purchase orders that were created before this date.
    /// Default is current date. Use either UTC or ISO 8601 formats.
    /// Date example: '2020-03-16'(yyyy-MM-dd). Date with Timestamp example: '2020-03-16T10:30:15Z'(yyyy-MM-dd'T'HH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("createdEndDate")]
    public DateTimeOffset? CreatedEndDate { get; set; }

    /// <summary>
    /// Fetches all purchase orders that have order lines with an expected ship date after this date. Use either UTC or ISO 8601 formats.
    /// Date example: '2020-03-16'(yyyy-MM-dd).
    /// Date with Timestamp example: '2020-03-16T10:30:15Z'(yyyy-MM-dd'T'HH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("fromExpectedShipDate")]
    public DateTimeOffset? FromExpectedShipDate { get; set; }

    /// <summary>
    /// Fetches all purchase orders that have order lines with an expected ship date before this date.
    /// Use either UTC or ISO 8601 formats.
    /// Date example: '2020-03-16'(yyyy-MM-dd).
    /// Date with Timestamp example: '2020-03-16T10:30:15Z'(yyyy-MM-dd'T'HH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("toExpectedShipDate")]
    public DateTimeOffset? ToExpectedShipDate { get; set; }

    /// <summary>
    /// Fetches all purchase orders that were modified before this date.
    /// Use either UTC or ISO 8601 formats.
    /// Date example: '2020-03-16'(yyyy-MM-dd).
    /// Date with Timestamp example: '2020-03-16T10:30:15Z'(yyyy-MM-dd'T'HH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("lastModifiedEndDate")]
    public DateTimeOffset? LastModifiedEndDate { get; set; }

    /// <summary>
    /// Default: "100"
    /// The number of orders to be returned.Cannot be larger than 200.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Default: "false"
    /// Provides the image URL and product weight in response, if available.Allowed values are true or false.
    /// </summary>
    [JsonPropertyName("productInfo")]
    public bool? ProductInfo { get; set; }

    /// <summary>
    /// Default: "SellerFulfilled"
    /// Specifies the type of shipNode.Allowed values are SellerFulfilled(Default), WFSFulfilled and 3PLFulfilled.
    /// </summary>
    [JsonPropertyName("shipNodeType")]
    public bool? ShipNodeType { get; set; }

    /// <summary>
    /// Specifies the type of program. Allowed value is TWO_DAY.
    /// </summary>
    [JsonPropertyName("shippingProgramType")]
    public bool? ShippingProgramType { get; set; }

    /// <summary>
    /// Default: "false"
    /// Provides additional attributes - originalCustomerOrderID, orderType - related to Replacement order, in response,
    /// if available.Allowed values are true or false.
    /// </summary>
    [JsonPropertyName("replacementInfo")]
    public bool? ReplacementInfo { get; set; }
}

