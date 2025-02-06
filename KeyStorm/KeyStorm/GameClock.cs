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


    public static bool CountDown()
    {
        //Stopwatch stopwatch = new Stopwatch();

        //while (stopwatch.Elapsed.TotalSeconds < seconds)
        //{
        //    //OutputProvider.WriteLine($"{seconds - stopwatch.Elapsed.TotalSeconds:F2} seconds remaining");
        //    stopwatch.Start();
        //}
        //return false;
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "C:\\Users\\t-ryanmoses\\source\\repos\\LeaperChooseAGame_Group7\\KeyStorm\\GameClockApp\\bin\\Debug\\net8.0\\GameClockApp.exe", // Path to the new console application
            UseShellExecute = true
        };

        Process clockProcess = Process.Start(startInfo);
        // Wait for the process to exit within the specified timeout
        bool exited = clockProcess.WaitForExit(8 * 1000);

        if (!exited)
        {
            // If the process did not exit within the timeout, kill it
            clockProcess.Kill();
            OutputProvider.WriteLine("The countdown process was terminated due to timeout.");
        }

        return true;
    }
}

