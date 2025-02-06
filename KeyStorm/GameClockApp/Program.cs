using System.Runtime.InteropServices;

namespace GameClockApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CountDown(5);


        }
        static void CountDown(int seconds)
        {
            while (seconds > 0)
            {
                Console.SetWindowSize(10, 10);
                Console.Clear();
                
                Console.SetCursorPosition(Console.WindowWidth - 5, 0);
                Console.WriteLine($"00:{seconds:D2}");
                Thread.Sleep(1000);
                seconds--;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time's up!");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', Console.WindowWidth - 10));
            Thread.Sleep(2000);
        }

    }
}
