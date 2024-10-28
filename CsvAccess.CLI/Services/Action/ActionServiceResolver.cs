using CsvAccess.core.Actions.Checkin;
using CsvAccess.core.Actions.Checkout;
using CsvAccess.core.Actions.Credentials;

namespace CsvAccess.CLI.Services.Action;

public class ActionServiceResolver
{
    private const string CHECKIN_COMMAND = "checkin";
    private const string CHECKOUT_COMMAND = "checkout";
    private const string CONFIGURATION_COMMAND = "config";

    public ActionServiceResolver()
    {

    }

    public core.Actions.Action GetActionFromCommand(string? command)
    {
        if (command == CHECKIN_COMMAND)
            return core.DependencyInjection.Services.Resolve<CheckinAction>();
        if (command == CHECKOUT_COMMAND)
            return core.DependencyInjection.Services.Resolve<CheckoutAction>();
        if (command == CONFIGURATION_COMMAND)
            return core.DependencyInjection.Services.Resolve<CredentialsAction>();
        throw new ArgumentException($"Unknown Command: {command}");
    }
}