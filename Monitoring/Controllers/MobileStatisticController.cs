namespace Monitoring.Controllers;

/// <summary>
/// Контроллер статистики по мобильному приложению.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MobileStatisticController : ControllerBase
{
    private readonly ILogger<MobileStatisticController> _logger;
    private readonly MobileStatisticInMemoryRepository _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="MobileStatisticController"/> class.
    /// </summary>
    /// <param name="logger"><see cref="ILogger"/>.</param>
    /// <param name="database"><see cref="MobileStatisticInMemoryRepository"/>.</param>
    public MobileStatisticController(ILogger<MobileStatisticController> logger, MobileStatisticInMemoryRepository database)
    {
        _logger = logger;
        _database = database;
    }

    /// <summary>
    /// Получить актуальную статистику по мобильному приложению.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="DeviceStatistic"/>.</returns>
    [HttpGet]
    public IEnumerable<DeviceStatistic> GetAll()
    {
        _logger.LogInformation("Statistic has been prepared for a client");

        return _database.Get();
    }

    /// <summary>
    /// Отправить статистику на хранение.
    /// </summary>
    /// <param name="statistic"><see cref="DeviceStatistic"/>.</param>
    [HttpPost]
    public void SendMetrics(DeviceStatistic statistic)
    {
        _database.Add(statistic);

        _logger.LogInformation("Metrics have been sent: {Id}", statistic.Id);
    }
}
