namespace CsvAccess.core.Actions;

public class CoreActionResult : ActionResult
{
    public bool Success { get; private set; }
    public string Message { get; private set; }

    private CoreActionResult() { }

    public static ActionResult CreateSuccess() =>
        new CoreActionResult()
        {
            Success = true
        };

    public static ActionResult CreateFailure(string message) =>
        new CoreActionResult()
        {
            Success = false,
            Message = message
        };
}