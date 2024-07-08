namespace Monitoring.Data;

/// <summary>
/// Реализация memory репозитория для статистики мобильных приложений.
/// </summary>
public class MobileStatisticMemoryRepository
{
    private readonly ConcurrentBag<MobileAppStatistic> _dataBase = new()
    {
        new(Guid.NewGuid(), "Random Guy", DeviceOSType.Android, "8.800.55.5"),
        new(Guid.NewGuid(), "The One", DeviceOSType.Windows, "8.800.55.5"),
        new(Guid.NewGuid(), "Another one", DeviceOSType.Linux, "8.800.44.5"),
        new(Guid.NewGuid(), "Anonymous", DeviceOSType.MacOs, "8.800.33.8"),
    };

    /// <summary>
    /// Получить данные о статистике мобильных приложений.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="MobileAppStatistic"/>.</returns>
    public IEnumerable<MobileAppStatistic> Get() =>
        _dataBase.ToArray();

    /// <summary>
    /// Записать данные о статистике мобильных приложений в базу.
    /// </summary>
    /// <param name="statistic"><see cref="MobileAppStatistic"/>.</param>
    public void Add(MobileAppStatistic statistic) =>
        _dataBase.Add(statistic);
}
