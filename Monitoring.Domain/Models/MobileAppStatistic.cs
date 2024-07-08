namespace Monitoring.Domain.Models;

/// <summary>
/// Модель данных о статистике мобильных приложений.
/// </summary>
/// <param name="Id">Идентификатор статистики.</param>
/// <param name="Username">Имя пользователя.</param>
/// <param name="OsType"><see cref="DeviceOsType"/>.</param>
/// <param name="AppVersion">Версия мобильного приложения.</param>
public record MobileAppStatistic(
    Guid Id,
    string? Username,
    DeviceOsType? OsType,
    string? AppVersion);
