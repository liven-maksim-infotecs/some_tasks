namespace Monitoring.Data.Extensions;

/// <summary>
/// Класс с методами-расширения <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Зарегистрировать уровень данных.
    /// </summary>
    /// <param name="collection"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection RegisterDataLayer(this IServiceCollection collection, IConfiguration configuration)
    {
        RegisterClassMapIfNot<MobileAppStatistic>();

        return collection
            .AddMongoDbClient(configuration)
            .AddScoped<MongoDbContext>()
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

    private static IServiceCollection AddMongoDbClient(this IServiceCollection collection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringNames.Mongo)!;

        MongoUrl url = MongoUrl.Create(connectionString);
        MongoClient mongoClient = new(url);

        return collection.AddSingleton<IMongoClient>(mongoClient);
    }


    private static void RegisterClassMapIfNot<T>()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
        {
            BsonClassMap.RegisterClassMap<T>();
        }
    }
}
