namespace Bet.Extensions.Walmart;

public static class WalmartExtensions
{
    /// <summary>
    /// Converts parameter list into query string.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    public static string CompileRequestUri(
        this IList<KeyValuePair<string, object>>? parameters,
        string requestUri)
    {
        if (parameters != null)
        {
            var d = parameters.Select(item =>
            {
                var v = item.Value.ToString();
                return $"{item.Key}={v}";
            });

            var ub = new UriBuilder("https://localhost")
            {
                Query = string.Join("&", d)
            };

            return $"{requestUri}{ub.Uri.Query}";
        }

        return requestUri;
    }

    public static async Task<WalmartHttpRequestException?> ValidateAsync(
        this HttpResponseMessage response,
        Stream? content,
        CancellationToken cancellationToken = default)
    {
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            var wex = new WalmartHttpRequestException($"Walmart Api failed", ex, ex.StatusCode);

            if (content != null)
            {
                try
                {
                    using var streamReader = new StreamReader(content);
                    var json = await streamReader.ReadToEndAsync();

                    var exp = new WalmartHttpRequestException($"Walmart Api failed: '{json}'", ex, ex.StatusCode);
                    exp.ResponseData = json;
                    return exp;
                }
                catch { }
            }

            return wex;
        }

        return null;
    }
}
