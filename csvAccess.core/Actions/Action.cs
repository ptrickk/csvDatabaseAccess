namespace CsvAccess.core.Actions;

public interface Action
{
    public ActionResult Execute(string[] arguments);
}