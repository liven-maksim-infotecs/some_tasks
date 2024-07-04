namespace Monitoring.Data;

public class SimpleDatabase
{
    private readonly ConcurrentBag<DeviceStatistic> _dataBase = new()
    {
        new(Guid.NewGuid(), "Random Guy", DeviceOSType.Android, "8.800.55.5"),
        new(Guid.NewGuid(), "The One", DeviceOSType.Windows, "8.800.55.5"),
        new(Guid.NewGuid(), "Another one", DeviceOSType.Linux, "8.800.44.5"),
        new(Guid.NewGuid(), "Anonymous", DeviceOSType.MacOs, "8.800.33.8"),
    };

    public IEnumerable<DeviceStatistic> Get() =>
        _dataBase.ToArray();

    public void Add(DeviceStatistic statistic) =>
        _dataBase.Add(statistic);
}
