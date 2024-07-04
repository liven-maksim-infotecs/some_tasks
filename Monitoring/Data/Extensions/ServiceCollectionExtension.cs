namespace Monitoring.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddData(this IServiceCollection collection) =>
        collection.AddSingleton<SimpleDatabase>();
}
