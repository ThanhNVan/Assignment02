using Microsoft.Extensions.DependencyInjection;

namespace Assignment02.LogicProviders;

public static class ServiceExtensions
{
    #region [ Methods - Add ]
    public static void AddLogicServices(this IServiceCollection services) {
        services.AddTransient<IAuthorLogicProvider, AuthorLogicProvider>();
        services.AddTransient<IBookAuthorLogicProvider, BookAuthorLogicProvider>();
        services.AddTransient<IBookLogicProvider, BookLogicProvider>();
        services.AddTransient<IPublisherLogicProvider, PublisherLogicProvider>();
        services.AddTransient<IRoleLogicProvider, RoleLogicProvider>();
        services.AddTransient<IUserLogicProvider, UserLogicProvider>();

        services.AddTransient<LogicContext>();
    }
    #endregion
}
