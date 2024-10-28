using CsvAccess.core.Actions;

namespace CsvAccess.CLI.Actions.Result;

internal class CommandLineActionResult : ActionResult
{
    public bool Success { get; private init; }
    public string Message { get; private init; }

    private CommandLineActionResult(){}

    public static ActionResult CreateSuccess() => new CommandLineActionResult()
    {
        Success = true,
    };

    public static ActionResult CreateFailure(string message) => new CommandLineActionResult()
    {
        Success = false,
        Message = message
    };
}