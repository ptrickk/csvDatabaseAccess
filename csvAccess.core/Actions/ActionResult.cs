namespace CsvAccess.core.Actions;

public interface ActionResult
{
    bool Success { get; }
    string Message { get; }
}