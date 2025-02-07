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
            Console.WriteLine("Ready");
            Thread.Sleep(2000);
            Console.WriteLine("Go");
            Thread.Sleep(1000);

            while (seconds > 0)
            {
                Console.Clear();
                Console.SetWindowSize(10, 10);
                
                Console.SetCursorPosition(Console.WindowWidth - 5, 0);
                Console.WriteLine($"00:{seconds:D2}");
                Thread.Sleep(1000);
                seconds--;
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;


            Console.Write(new string(' ', Console.WindowWidth));
            Console.WriteLine("Time's up!");
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Thread.Sleep(2000);
        }

    }
}
