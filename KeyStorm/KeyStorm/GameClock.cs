using KeyStorm;
using KeyStorm.Interfaces;

public static class GameClock
{
    private static IOutputProvider _outputProvider = new ConsoleOutputProvider();

    public static IOutputProvider OutputProvider { 
        get { return _outputProvider; }
    }

    public static void StartCountDown(int seconds)
    {
        while (seconds > 0)
        {
            OutputProvider.Clear();
            OutputProvider.WriteLine($"00:{seconds:D2}");
            Thread.Sleep(1000);
            seconds--;
        }
        OutputProvider.Clear();
        OutputProvider.WriteLine("Time's up!");
    }
}
