namespace Monitoring.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MobileStatisticController : ControllerBase
{
    private readonly ILogger<MobileStatisticController> _logger;
    private readonly SimpleDatabase _database;

    public MobileStatisticController(ILogger<MobileStatisticController> logger, SimpleDatabase database)
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
