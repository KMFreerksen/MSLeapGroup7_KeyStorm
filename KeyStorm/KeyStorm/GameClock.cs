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


    public static bool CountDown(int seconds)
    {
        Stopwatch stopwatch = new Stopwatch();

        while (stopwatch.Elapsed.TotalSeconds < seconds)
        {
            //OutputProvider.WriteLine($"{seconds - stopwatch.Elapsed.TotalSeconds:F2} seconds remaining");
            stopwatch.Start();
        }
        return false;

    }
}

