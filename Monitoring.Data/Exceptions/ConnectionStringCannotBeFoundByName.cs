namespace Monitoring.Data.Exceptions;

public class ConnectionStringCannotBeFoundByName : Exception
{
    private const string MessageTemplate = "Connection string cannot be found by a name. Check configuration";

    public ConnectionStringCannotBeFoundByName()
        : base(MessageTemplate)
    {

    }
}
