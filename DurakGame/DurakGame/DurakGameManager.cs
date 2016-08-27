using System;

namespace DurakGame
{
    class DurakGameManager
    {
        private CardDeck _deck;
        private MainMenu _menu;

        bool isGameStarted = false;
        bool isGameQuit = false;
        bool isOutOfMainMenu = false;
        string userInput = string.Empty;

        private enum GameSate
        {
            PreLoad,
            MainMenu,
            Playing,
            Paused,
            GameOver,
            Quit
        }

        private GameSate currentGameState = GameSate.PreLoad;

        private void MainMenu()
        {
            currentGameState = GameSate.MainMenu;

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Durak game!\n");

                Console.WriteLine("1. Start new game (start)");
                Console.WriteLine("2. Save game (save)");
                Console.WriteLine("3. Load game (load)");
                Console.WriteLine("4. Options (options)");
                Console.WriteLine("5. Quit (quit)");

                Console.WriteLine("Choose variant: ");

                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "start":
                        isGameStarted = true;
                        Console.WriteLine("Starting game");
                        PlayGame();
                        break;
                    case "save":
                        Console.WriteLine("Not implemented!");
                        break;
                    case "load":
                        Console.WriteLine("Not implemented!");
                        break;
                    case "options":
                        Console.WriteLine("Not implemented!");
                        break;
                    case "quit":
                        isGameQuit = true;
                        Console.WriteLine("Quit!");
                        QuitGame();
                        break;
                    default:
                        Console.WriteLine("Incorrect choice!");
                        break;
                }

                Console.ReadKey(false);

                if (isGameStarted || isGameQuit)
                {
                    isOutOfMainMenu = true;
                }
            }
            while (!isOutOfMainMenu);

            Console.WriteLine("Out of Main Menu!");
        }





        private void PlayGame()
        {
            currentGameState = GameSate.Playing;

            _deck.ShowCards();

            //
        }





        private void PauseGame()
        {
            currentGameState = GameSate.Paused;
        }

        private void GameOver()
        {
            currentGameState = GameSate.GameOver;
        }

        private void QuitGame()
        {
            currentGameState = GameSate.Quit;
        }

        public void InitGame()
        {
            _deck = new CardDeck();
            _deck.InitCardDeck();

            Play();
        }

        private void Play()
        {
            while (true)
            {
                switch (currentGameState)
                {
                    case GameSate.PreLoad:
                        currentGameState = GameSate.MainMenu;
                        break;
                    case GameSate.MainMenu:
                        MainMenu();
                        break;
                    case GameSate.Playing:
                        PlayGame();
                        break;
                    case GameSate.Paused:
                        PauseGame();
                        break;
                    case GameSate.GameOver:
                        GameOver();
                        break;
                    case GameSate.Quit:
                        QuitGame();
                        break;
                    default:
                        break;
                }
            }
        }

        private struct Player
        {
            Card[] CardOnTable;
            Card[] _cards;
            bool _isPlaying; // Ходит ли игрок?
            //void Turn();
        }

        //void DisplayCards(Card[] hand);

        // Track game progress.
        private struct GameTracker
        {
            //void SaveGame();
            //void LoadGame();
            //int GetScore();
        }

        private struct GameStage
        {
            Card[] _cards;
        }

        private struct PlayedGame
        {
            GameStage[] _stages;
        }
    }
}
