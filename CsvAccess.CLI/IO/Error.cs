namespace CsvAccess.CLI.IO;

public class Error : Display
{
    private const string ERROR_PREFIX = "Error: ";
    public string Message { get; set; }
    public bool Continue { get; set; }

    public void Show()
    {
        Console.WriteLine($"{ERROR_PREFIX}{Message}");
    }

    private Error(){}

    public static Error CreateContinue(string message) =>
        new()
        {
            Message = message,
            Continue = true
        };

    public static Error CreateStop(string message) =>
        new()
        {
            Message = message,
            Continue = false
        };
}