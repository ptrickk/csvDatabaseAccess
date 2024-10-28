using System.Diagnostics;
using CsvAccess.CLI.Actions.Result;
using CsvAccess.core.Actions;

namespace CsvAccess.CLI.File.Open;

public class FileOpener
{
    public ActionResult Open(string path)
    {
        using Process openFileProcess = new Process();
        openFileProcess.StartInfo.FileName = "notepad.exe";
        openFileProcess.StartInfo.Arguments = path;

        try
        {
            bool result = openFileProcess.Start();
            openFileProcess.WaitForExit();
            return CommandLineActionResult.CreateSuccess();
        }
        catch
        {
            return CommandLineActionResult.CreateFailure("Could not open credentials");
        }
    }
}