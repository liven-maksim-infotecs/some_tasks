namespace Metrics.Data;

public class SimpleDatabase
{
    private readonly ConcurrentBag<DeviceStatistic> _dataBase = new();

    public IEnumerable<DeviceStatistic> Get() =>
        _dataBase.ToArray();

    public void Add(DeviceStatistic statistic) =>
        _dataBase.Add(statistic);
}
