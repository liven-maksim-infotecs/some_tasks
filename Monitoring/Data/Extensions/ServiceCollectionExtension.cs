namespace Monitoring.Data.Extensions;

/// <summary>
/// Класс с методами-расширения <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Добавить слой Data в приложение.
    /// </summary>
    /// <param name="collection"><see cref="IServiceCollection"/>.</param>
    /// <returns>Модифицированный <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddData(this IServiceCollection collection) =>
        collection.AddSingleton<SimpleDatabase>();
}
