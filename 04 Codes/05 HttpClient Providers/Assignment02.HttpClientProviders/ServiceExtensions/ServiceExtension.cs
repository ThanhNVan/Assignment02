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
        services.AddTransient<IBookAuthorHttpClientProvider, BookAuthorHttpClientProvider>();   
        services.AddTransient<IBookHttpClientProvider, BookHttpClientProvider>();   
        services.AddTransient<IPublisherHttpClientProvider, PublisherHttpClientProvider>();   
        services.AddTransient<IRoleHttpClientProvider, RoleHttpClientProvider>();   
        services.AddTransient<IUserHttpClientProvider, UserHttpClientProvider>();   

        services.AddTransient<HttpClientContext>();
    }
    #endregion
}
