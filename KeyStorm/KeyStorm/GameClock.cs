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
            FileName = "GameClockApp.exe", // Path to the new console application
            Arguments = seconds.ToString(),
            UseShellExecute = true
        };

        Process clockProcess = Process.Start(startInfo);
        clockProcess.WaitForExit();

        return false;
    }
}

