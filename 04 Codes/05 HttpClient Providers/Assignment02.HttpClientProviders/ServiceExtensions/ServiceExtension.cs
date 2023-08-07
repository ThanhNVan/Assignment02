using Assignment02.EntityProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment02.HttpClientProviders;

public static class ServiceExtension
{
    #region [ Methods - Add ]
    public static void AddHttpClientProviders(this IServiceCollection services, IConfiguration configuration) {
        services.AddHttpClient(RoutingUrl.BaseClientName, clients => {
            clients.BaseAddress = new Uri(configuration["BaseUrl"]);
        });

        services.AddTransient<IAuthorHttpClientProvider, AuthorHttpClientProvider>();   

        services.AddTransient<HttpClientContext>();
    }
    #endregion
}
