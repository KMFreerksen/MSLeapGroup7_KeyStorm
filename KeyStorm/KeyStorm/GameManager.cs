using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyStorm.Interfaces;

namespace KeyStorm
{
    // Game Manager class to hold the main game loop and logic
    public class GameManager
    {

        private IInputProvider inputProvider;

        private IOutputProvider outputProvider;

        private LoadText LoadText;

        private string? phrase;

        public GameState GameState { get; private set; }

        // Constructor for the GameManager class
        public GameManager() : this(new ConsoleInputProvider(), new ConsoleOutputProvider())
        {
        }

        public GameManager(IInputProvider inputProvider, IOutputProvider outputProvider)

        {
            // Error handling for null input providers
            if (inputProvider == null)
            {
                throw new ArgumentNullException(nameof(inputProvider));
            }
            // Error handling for null output providers
            if (outputProvider == null)
            {
                throw new ArgumentNullException(nameof(outputProvider));
            }
            // Set the input provider and output provider
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;

            // Set the GameState to MainMenu
            GameState = GameState.MainMenu;
            LoadText = new LoadText();
            LoadText.Load(@"text-phrases.txt");
        }

        // Calculates correct words method
        public (int correctWords, int incorrectWords) CalculateWords(string userInput, string phrase)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(phrase))
            {
                return (0, 0);
            }

            int correctWords = 0;
            int incorrectWords = 0;

            string[] userWords = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] phraseWords = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < Math.Min(userWords.Length, phraseWords.Length); i++)
            {
                if (userWords[i].Trim().Equals(phraseWords[i].Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    correctWords++;
                }
                else
                {
                    incorrectWords++;
                }
            }
            incorrectWords += Math.Abs(userWords.Length - phraseWords.Length);
            return (correctWords, incorrectWords);
        }
        // Start game method to begin the game loop
        public void StartGame()
        {
            while (true) // main game loop
            {
                switch (GameState)
                {
                    case GameState.MainMenu:
                        // Display the main menu
                        outputProvider.WriteLine("Welcome to KeyStorm!");
                        outputProvider.WriteLine("Press any key to start the game");

                        // Read the input
                        Console.ReadKey();
                        outputProvider.Clear();

                        // Set the GameState to ReadyToStart
                        GameState = GameState.ReadyToStart;
                        break;

                    case GameState.ReadyToStart:
                        // Display the phrase
                        phrase = LoadText.GetRandomPhrase();
                        outputProvider.WriteLine(phrase);

                        GameState = GameState.RaceStarted;
                        break;
                    case GameState.RaceStarted:
                       // Call the GameClock.CountDown method to start the countdown
                        Process clockProcess = GameClock.CountDown();
                        
                        Thread.Sleep(3000);
                        // Capture the start time
                        DateTime startTime = DateTime.Now;

                        outputProvider.WriteLine("\nType The Phrase: \n");

                        StringBuilder userInput = new StringBuilder();
                        while (!clockProcess.HasExited)
                        {
                            if (Console.KeyAvailable)
                            {
                                char key = inputProvider.ReadKey();
                                userInput.Append(key);
                                outputProvider.Write(key.ToString());
                            }
                        }
                        // Capture the end time
                        DateTime endTime = DateTime.Now;

                        // Calculate the total time in seconds
                        double totalTimeInSeconds = (endTime - startTime).TotalSeconds;

                        // Calculate words per minute
                        WordCounter wordCounter = new WordCounter();
                        double wpm = wordCounter.CalculateWPM(userInput.ToString(), totalTimeInSeconds);

                        var (correctWords, incorrectWords) = CalculateWords(userInput.ToString(), phrase!);
                        if (totalTimeInSeconds >= 30)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            outputProvider.WriteLine("\n\nTime's up!");
                            Console.ResetColor();
                        }

                        outputProvider.WriteLine($"Your words per minute: {wpm:F2}");
                        outputProvider.WriteLine($"Correct words: {correctWords}");
                        outputProvider.WriteLine($"Incorrect words: {incorrectWords}");

                        outputProvider.WriteLine();

                        GameState = GameState.RaceOver;
                        break;
                    case GameState.RaceOver:
                        // TODO display the
                        outputProvider.WriteLine("\nGame Over!");
                        GameState = GameState.GameOverLeaderboard;
                        break;

                    case GameState.GameOverLeaderboard:
                        // TODO display the game over leaderboard
                        // TODO handle user input for the game over leaderboard
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
