namespace CsvAccess.CLI.IO;

public interface Display
{
    string Message { get; }
    bool Continue { get; }

    void Show();
}