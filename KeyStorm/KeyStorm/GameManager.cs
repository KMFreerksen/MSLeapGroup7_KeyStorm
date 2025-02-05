using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStorm
{
    // Game Manager class to hold the main game loop and logic
    public class GameManager
    {

        // TODO create an input provider to handle user input
        // TODO create an output provider to handle game output

        public GameState GameState { get; private set; }

        public GameManager() // require the input and output providers to be passed in

        // TODO initialize the input provider
        // TODO initialize the output provider

        {
            GameState = GameState.MainMenu;
        }

        // Start game method to begin the game loop
        public void StartGame()
        {
            while (true) // main game loop
            {
                switch (GameState)
                {
                    case GameState.MainMenu:
                        // TODO display the main menu
                        Console.WriteLine("Welcome to KeyStorm!");
                        // TODO handle user input for the main menu
                        Console.WriteLine("Press any key to start the game");
                        Console.ReadKey();
                        break;
                    case GameState.ReadyToStart:
                        // TODO display the ready to start screen
                        // TODO handle user input for the ready to start screen
                        break;
                    case GameState.Playing:
                        // TODO display the game screen
                        // TODO handle user input for the game screen
                        break;
                    case GameState.RaceOver:
                    // TODO display the
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
