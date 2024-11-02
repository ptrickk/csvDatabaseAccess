using System.Diagnostics;
using CsvAccess.CLI.Actions.Result;
using CsvAccess.core.Actions;
using CsvAccess.core.Encryption;

namespace CsvAccess.CLI.File.Open;

public class FileOpener
{
    private readonly EncryptionService _encryptionService;
    public FileOpener(EncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public ActionResult Open(string path)
    {
        _encryptionService.TryDecrypt(path);
        using Process openFileProcess = new Process();
        openFileProcess.StartInfo.FileName = "notepad.exe";
        openFileProcess.StartInfo.Arguments = path;

        try
        {
            bool result = openFileProcess.Start();
            openFileProcess.WaitForExit();
            _encryptionService.TryEncrypt(path);
            return CommandLineActionResult.CreateSuccess();
        }
        catch
        {
            _encryptionService.TryEncrypt(path);
            return CommandLineActionResult.CreateFailure("Could not open credentials");
        }
    }
}