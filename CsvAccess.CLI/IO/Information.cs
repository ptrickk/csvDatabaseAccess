namespace CsvAccess.CLI.IO;

public class Information : Display
{
    public string Message { get; set; }
    public bool Continue { get; set; }

    public void Show()
    {
        Console.WriteLine(Message);
    }

    private Information() { }

    public static Information Create(string message) =>
        new()
        {
            Message = message,
            Continue = true
        };
}