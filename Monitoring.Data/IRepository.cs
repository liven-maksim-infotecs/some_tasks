namespace Monitoring.Data;

/// <summary>
/// Обобщённый репозиторий.
/// </summary>
/// <typeparam name="T">Тип сущности, с которым работает репозиторий.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Получить все сущности.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns><see cref="Task{TResult}"/>, где результат — коллекция сущностей <see cref="T"/>.</returns>
    public Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить сущность в базу.
    /// </summary>
    /// <param name="statistic">Сущность на сохранение.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    public Task AddAsync(T statistic, CancellationToken cancellationToken = default);
}
