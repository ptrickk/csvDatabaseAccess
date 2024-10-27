namespace CsvAccess.core.Actions.Checkin
{
    public interface CheckinAction : Action
    {
        public ActionResult CheckinTable(string path);
    }
}
