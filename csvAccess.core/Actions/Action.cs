namespace CsvAccess.core.Actions;

public interface Action
{
    public bool DatabaseReliant { get; }
    public ActionResult Execute(string[] arguments);
}