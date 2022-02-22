using System.Net;

namespace Bet.Extensions.Walmart;

public class WalmartHttpRequestException : HttpRequestException
{
    public WalmartHttpRequestException()
    {
    }

    public WalmartHttpRequestException(string? message) : base(message)
    {
        ResponseData = message;
    }

    public WalmartHttpRequestException(string? message, Exception? inner) : base(message, inner)
    {
        ResponseData = message;
    }


    public WalmartHttpRequestException(string? message, Exception? inner, HttpStatusCode? statusCode) : base(message, inner, statusCode)
    {
        ResponseData = message;
    }


    public string? ResponseData { get; set; }
}
