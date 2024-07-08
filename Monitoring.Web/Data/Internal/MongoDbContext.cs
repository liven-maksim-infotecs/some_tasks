namespace Monitoring.Web.Data.Internal;

/// <summary>
/// Наивная реализация контекста для MongoDB.
/// </summary>
internal class MongoDbContext
{
    private readonly IMongoDatabase _database;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="client"><see cref="IMongoClient"/>.</param>
    public MongoDbContext(IMongoClient client) =>
        _database = client.GetDatabase(DbNames.MobileStatistic);

    /// <summary>
    /// Получить коллекцию по имени и типу.
    /// </summary>
    /// <param name="collectionName">Имя коллекции.</param>
    /// <typeparam name="T">Тип сущности.</typeparam>
    /// <returns><see cref="IMongoCollection{TDocument}"/>.</returns>
    public IMongoCollection<T> GetCollection<T>(string collectionName) =>
        _database.GetCollection<T>(collectionName);

    /// <summary>
    /// Получить коллекцию по типу.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    /// <returns><see cref="IMongoCollection{TDocument}"/>.</returns>
    public IMongoCollection<T> GetCollection<T>() =>
        GetCollection<T>(typeof(T).Name);
}
