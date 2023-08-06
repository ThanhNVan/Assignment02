using Microsoft.Extensions.DependencyInjection;

namespace Assignment02.LogicProviders;

public static class ServiceExtensions
{
    #region [ Methods - Add ]
    public static void AddLogicServices(this IServiceCollection services) {
        services.AddTransient<IAuthorLogicProvider, AuthorLogicProvider>();

        services.AddTransient<LogicContext>();
    }
    #endregion
}
