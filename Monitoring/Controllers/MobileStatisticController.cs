namespace Monitoring.Controllers;

/// <summary>
/// Контроллер статистики по мобильному приложению.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MobileStatisticController : ControllerBase
{
    private readonly ILogger<MobileStatisticController> _logger;
    private readonly MobileStatisticMemoryRepository _database;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="logger"><see cref="ILogger"/>.</param>
    /// <param name="database"><see cref="MobileStatisticMemoryRepository"/>.</param>
    public MobileStatisticController(ILogger<MobileStatisticController> logger, MobileStatisticMemoryRepository database)
    {
        _logger = logger;
        _database = database;
    }

    /// <summary>
    /// Получить актуальную статистику по мобильному приложению.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="DeviceStatistic"/>.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Статистика подготовлена успешно", typeof(IEnumerable<DeviceStatistic>))]
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
    /// <returns><see cref="IActionResult"/>.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Статистика записана успешно")]
    [HttpPost]
    public IActionResult SendMetrics(DeviceStatistic statistic)
    {
        _database.Add(statistic);

        _logger.LogInformation("Metrics have been sent: {Id}", statistic.Id);
        return Ok();
    }
}
