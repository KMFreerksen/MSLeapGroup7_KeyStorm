namespace KeyStorm
{
    class Program
    {

        public static void Main(string[] args)
        {
            var gm = new GameManager();
            gm.StartGame();
            Console.WriteLine("Welcome to KeyStorm!");
            GameClock.StartCountDown(30);
        }
    }
}