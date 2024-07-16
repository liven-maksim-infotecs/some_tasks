namespace Monitoring.Data.Exceptions;

/// <summary>
/// Исключение - Строка подключения не найдена по имени.
/// </summary>
public class ConnectionStringCannotBeFoundByName : Exception
{
    private const string MessageTemplate = "Connection string cannot be found by a name. Check configuration";

    /// <summary>
    /// ctor.
    /// </summary>
    public ConnectionStringCannotBeFoundByName()
        : base(MessageTemplate)
    {

    }
}
