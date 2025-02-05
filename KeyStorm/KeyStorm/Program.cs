namespace KeyStorm
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to KeyStorm!");
            var read = new LoadText();
            read.Load();
        }
    }
}