using System;
using System.Runtime.InteropServices;

namespace GameClockApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CountDown(30);
        }
        static void CountDown(int seconds)
        {
            Console.WriteLine("Ready...Wait For Timer To Start".ToUpper());
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("Go!!!".ToUpper());
            Thread.Sleep(1000);

            while (seconds > 0)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth - 5, 0);
                Console.WriteLine($"00:{seconds:D2}");
                Thread.Sleep(1000);
                seconds--;
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.WriteLine("Time's up!");
            Console.WriteLine(new string(' ', 30));
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
