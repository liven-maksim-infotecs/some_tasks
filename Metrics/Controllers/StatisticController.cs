namespace Metrics.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticController : ControllerBase
{
    private readonly ILogger<StatisticController> _logger;
    private readonly SimpleDatabase _database;

    public StatisticController(ILogger<StatisticController> logger, SimpleDatabase database)
    {
        _logger = logger;
        _database = database;
    }

    [HttpGet]
    public IEnumerable<DeviceStatistic> Get()
    {
        _logger.LogInformation("Statistic has been prepared for a client");

        return _database.Get();
    }

    [HttpPost]
    public void SendMetrics(DeviceStatistic statistic)
    {
        _database.Add(statistic);

        _logger.LogInformation("Metrics have been sent: {Id}", statistic.Id);
    }
}
