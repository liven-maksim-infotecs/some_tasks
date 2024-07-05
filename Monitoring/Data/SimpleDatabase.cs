namespace Monitoring.Data;

/// <summary>
/// Простая реализация базы.
/// </summary>
public class SimpleDatabase
{
    private readonly ConcurrentBag<DeviceStatistic> _dataBase = new()
    {
        new(Guid.NewGuid(), "Random Guy", DeviceOSType.Android, "8.800.55.5"),
        new(Guid.NewGuid(), "The One", DeviceOSType.Windows, "8.800.55.5"),
        new(Guid.NewGuid(), "Another one", DeviceOSType.Linux, "8.800.44.5"),
        new(Guid.NewGuid(), "Anonymous", DeviceOSType.MacOs, "8.800.33.8"),
    };

    /// <summary>
    /// Получить данные о статистике.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="DeviceStatistic"/>.</returns>
    public IEnumerable<DeviceStatistic> Get() =>
        _dataBase.ToArray();

    /// <summary>
    /// Записать статистику в базу.
    /// </summary>
    /// <param name="statistic"><see cref="DeviceStatistic"/>.</param>
    public void Add(DeviceStatistic statistic) =>
        _dataBase.Add(statistic);
}
