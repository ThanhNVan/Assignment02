using Microsoft.Extensions.DependencyInjection;

namespace Assignment02.DataProviders;

public static class ServiceExtension
{
    #region [ Methods - Add ]
    public static void AddDataServices(this IServiceCollection services) {
        services.AddTransient<IAuthorDataProvider, AuthorDataProvider>();

        services.AddTransient<DataContext>();
    }
    #endregion
}
