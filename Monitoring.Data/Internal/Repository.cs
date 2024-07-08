namespace Monitoring.Data.Internal;

/// <summary>
/// Реализация репозитория <see cref="IRepository{T}"/>.
/// </summary>
/// <typeparam name="T">Тип сущности, с которым работает репозиторий.</typeparam>
internal class Repository<T> : IRepository<T>
{
    private readonly IMongoCollection<T> _collection;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="context"><see cref="MongoDbContext"/>.</param>
    public Repository(MongoDbContext context) =>
        _collection = context.GetCollection<T>();

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _collection.AsQueryable().ToListAsync(cancellationToken);

    /// <inheritdoc />
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await _collection.InsertOneAsync(entity, default, cancellationToken);
}
