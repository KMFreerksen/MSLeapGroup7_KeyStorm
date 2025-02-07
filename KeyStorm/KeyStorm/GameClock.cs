using System.Diagnostics;
using KeyStorm;
using KeyStorm.Interfaces;

public static class GameClock
{
    private static IOutputProvider _outputProvider = new ConsoleOutputProvider();
    private static IInputProvider _inputProvider = new ConsoleInputProvider();

    public static IOutputProvider OutputProvider
    {
        get { return _outputProvider; }
    }


    public static Process CountDown()
    {
        // Construct the dynamic file path
        string currentDirectory = Directory.GetCurrentDirectory();
        string relativePath = @"..\..\..\..\GameClockApp\bin\Debug\net8.0\GameClockApp.exe";
        string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = filePath,
            UseShellExecute = true
        };

        Process clockProcess = Process.Start(startInfo);

        // Wait for the process to exit within the specified timeout
        //bool exited = clockProcess.WaitForExit(40 * 1000);

        //if (!exited)
        //{
        //    // If the process did not exit within the timeout, kill it
        //    clockProcess.Kill();
        //}

        return clockProcess;
    }
}

