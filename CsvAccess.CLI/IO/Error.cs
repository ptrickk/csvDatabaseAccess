namespace CsvAccess.CLI.IO;

public class Error : Display
{
    private const string ERROR_PREFIX = "Error:";
    public string Message { get; set; }
    public void Show()
    {
        Console.WriteLine($"{ERROR_PREFIX}{Message}");
    }

    private Error(){}

    public static Error Create(string message) =>
        new()
        {
            Message = message
        };
}