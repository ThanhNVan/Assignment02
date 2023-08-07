using Microsoft.Extensions.DependencyInjection;

namespace Assignment02.DataProviders;

public static class ServiceExtension
{
    #region [ Methods - Add ]
    public static void AddDataServices(this IServiceCollection services) {
        services.AddTransient<IAuthorDataProvider, AuthorDataProvider>();
        services.AddTransient<IBookDataProvider, BookDataProvider>();
        services.AddTransient<IBookAuthorDataProvider, BookAuthorDataProvider>();
        services.AddTransient<IPublisherDataProvider, PublisherDataProvider>();
        services.AddTransient<IRoleDataProvider, RoleDataProvider>();
        services.AddTransient<IUserDataProvider, UserDataProvider>();

        services.AddTransient<DataContext>();
    }
    #endregion
}
