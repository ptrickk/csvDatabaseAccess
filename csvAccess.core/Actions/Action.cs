namespace CsvAccess.core.Actions;

public interface Action
{
    public bool ConnectionReliant { get; }
    public ActionResult Execute(string[] arguments);
}