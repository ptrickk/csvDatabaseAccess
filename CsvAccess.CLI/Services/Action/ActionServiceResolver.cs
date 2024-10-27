using CsvAccess.core.Actions.Checkin;
using CsvAccess.core.Actions.Checkout;

namespace CsvAccess.CLI.Services.Action;

public class ActionServiceResolver
{
    private const string CHECKIN_COMMAND = "checkin";
    private const string CHECKOUT_COMMAND = "checkout";

    public ActionServiceResolver()
    {

    }

    public core.Actions.Action GetActionFromCommand(string command)
    {
        return command switch
        {
            CHECKIN_COMMAND => core.DependencyInjection.Services.Resolve<CheckinAction>(),
            CHECKOUT_COMMAND => core.DependencyInjection.Services.Resolve<CheckoutAction>(),
            _ => throw new ArgumentException($"Unknown Command: {command}")
        };
    }
}