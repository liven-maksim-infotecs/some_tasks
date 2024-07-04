namespace Metrics.Data.Models;

public record DeviceStatistic(
    Guid Id,
    string Username,
    DeviceOSType OsType,
    string AppVersion);
