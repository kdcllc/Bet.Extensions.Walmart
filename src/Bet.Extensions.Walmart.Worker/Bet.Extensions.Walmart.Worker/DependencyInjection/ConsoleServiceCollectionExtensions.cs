namespace Microsoft.Extensions.DependencyInjection;

public static class ConsoleServiceCollectionExtensions
{
    public static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
    {
        services.AddScoped<IMain, Main>();

        services.AddWalmartClient((o, sp) =>
        {
            // enable custom mock server here
            // o.CustomUrl = new Uri("https://localhost:7297");
        });
    }
}
