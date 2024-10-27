namespace CsvAccess.CLI;

internal class Command
{
    public string? DatabaseSystem { get; private set; }

    public string? CommandName { get; private set; }

    public string[] CommandArguments { get; private set; }

    public Command(string[] args)
    {
        if (args.Length == 0)
        {
            return;
        }
        DatabaseSystem = args[0];

        if (args.Length == 1)
        {
            return;
        }
        CommandName = args[1];

        if (args.Length > 2)
        {
            CommandArguments = args[2..];
        }
    }
}