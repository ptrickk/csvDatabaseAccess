namespace CsvAccess.core.Actions.Checkout
{
    public interface CheckoutAction : Action
    {
        public ActionResult CheckoutTable(string tableName, string destination);
    }
}
