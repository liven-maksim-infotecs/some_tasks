namespace Monitoring.Controllers;

/// <summary>
/// Контроллер статистики по мобильным приложениям.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MobileStatisticController : ControllerBase
{
    private readonly ILogger<MobileStatisticController> _logger;
    private readonly IRepository<MobileAppStatistic> _repository;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="logger"><see cref="ILogger"/>.</param>
    /// <param name="repository"><see cref="IRepository{T}"/> для работы с <see cref="MobileAppStatistic"/>.</param>
    public MobileStatisticController(ILogger<MobileStatisticController> logger, IRepository<MobileAppStatistic> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    /// <summary>
    /// Получить актуальную статистику по мобильному приложению.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Коллекция элементов <see cref="MobileAppStatistic"/>.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Статистика подготовлена успешно", typeof(IEnumerable<MobileAppStatistic>))]
    [HttpGet]
    public async Task<IEnumerable<MobileAppStatistic>> GetAll(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Statistic has been prepared for a client");

        return await _repository.GetAllAsync(cancellationToken);
    }

    /// <summary>
    /// Отправить статистику на хранение.
    /// </summary>
    /// <param name="statistic"><see cref="MobileAppStatistic"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Статистика записана успешно")]
    [HttpPost]
    public async Task SendMetrics(MobileAppStatistic statistic, CancellationToken cancellationToken = default)
    {
        await _repository.AddAsync(statistic, cancellationToken);

        _logger.LogInformation("Metrics have been sent: {Id}", statistic.Id);
    }
}
