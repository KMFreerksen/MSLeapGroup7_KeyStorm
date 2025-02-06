using System;
using System.Collections.Generic;
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
                        inputProvider.Read();

                        // Set the GameState to ReadyToStart
                        GameState = GameState.ReadyToStart;

                        break;
                    case GameState.ReadyToStart:
                        // TODO display the ready to start screen
                        // TODO handle user input for the ready to start screen

                        
                        outputProvider.WriteLine(LoadText.GetRandomPhrase());
                        outputProvider.WriteLine();
                        outputProvider.WriteLine("Press Enter to start your response");
                        String userInput = inputProvider.Read();
                        
                         GameState = GameState.RaceStarted;
                        

                        break;

                    case GameState.RaceStarted:
                        // TODO display the game screen
                        // TODO handle user input for the game screen
                        // blank line
                        outputProvider.WriteLine();
                        // Enter the input
                        String input = inputProvider.Read();

                        // Check if the input is empty
                        if (string.IsNullOrEmpty(input))
                        {
                            continue;
                        }
                        else
                        {
                            GameState = GameState.RaceOver;
                        }

                        break;
                    case GameState.RaceOver:
                        // display game menu
                        outputProvider.WriteLine("Game Over!");

                        // Delay for 5 seconds
                        System.Threading.Thread.Sleep(5000);
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
