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
            while (seconds > 0)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth - 5, 0);
                Console.WriteLine($"00:{seconds:D2}");
                Thread.Sleep(1000);
                seconds--;
            }

            Console.Clear();
            Console.WriteLine("Time's up!");
        }

    }
}
