using System.Net.Http.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models.Authentication;

using Microsoft.Extensions.Options;

public class Main : IMain
{
    private readonly ILogger<Main> _logger;
    private readonly WalmartOptions _options;
    private readonly IWalmartBaseClient _baseClient;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Main(
        IWalmartBaseClient baseClient,
        IOptions<WalmartOptions> options,
        IHostApplicationLifetime applicationLifetime,
        IConfiguration configuration,
        ILogger<Main> logger)
    {
        _options = options.Value;
        _baseClient = baseClient ?? throw new ArgumentNullException(nameof(baseClient));
        _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IConfiguration Configuration { get; set; }

    public async Task<int> RunAsync()
    {
        _logger.LogInformation("Main executed");

        // use this token for stopping the services
        var cancellationToken = _applicationLifetime.ApplicationStopping;

        var tasks = new List<Task<AuthDetails>>();

        for (var i = 0; i < 300; i++)
        {
            var response = _baseClient.HttpClient.GetFromJsonAsync<AuthDetails>($"/{_options.Version}/token/detail", cancellationToken);
            tasks.Add(response);
        }

        var r = await Task.WhenAll(tasks);

        foreach (var item in r)
        {
            _logger.LogInformation(item.ExpireAt);
        }

        return 0;
    }
}
