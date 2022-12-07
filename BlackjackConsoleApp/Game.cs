using System;
namespace BlackjackConsoleApp
{
	public class Game
	{
        private const string GameVersion = "v1.0";

        public const int BlackjackValue = 21;
		public const int stopDrawingCardAtValue = 17;

        private static Deck deckOfCards = new();
        private static Player playerOne;
        private static Player playerTwo;

        public Game(string playerOneName = "Spiller Ein", string playerTwoName = "Spiller To")
        {
            playerOne = new(playerOneName);
            playerTwo = new(playerTwoName);
        }

        public static string GetGameVersion()
        {
            return GameVersion;
        }

        public void GameLoop()
        {
            InitializeHands();

            while (!playerOne.IsBlackjack()
                   && playerOne.GetValueOfHand() < Game.stopDrawingCardAtValue)
            {
                playerOne.Hand.Add(deckOfCards.DrawCard());
            }

            while (!playerTwo.IsBlackjack()
                   && playerTwo.GetValueOfHand() <= playerOne.GetValueOfHand())
            {
                playerTwo.Hand.Add(deckOfCards.DrawCard());
            }

            WriteResultsToConsole();
        }

        private static void InitializeHands()
        {
            deckOfCards.Initialize();
            playerOne.Hand = deckOfCards.DealHand();
            playerTwo.Hand = deckOfCards.DealHand();
        }

        private static string CheckWinner()
        {
            if (playerTwo.GetValueOfHand() > Game.BlackjackValue)
            {
                return playerOne.Name;
            }

            return playerTwo.Name;
        }

        private static void WriteResultsToConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Vinner: ");
            Console.ResetColor();
            Console.Write(CheckWinner() + "\n\n");

            Console.Write(playerOne.Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" | ");
            playerOne.PrintValueOfHandToConsole();
            Console.Write(" | ");
            Console.ResetColor();
            playerOne.PrintHandToConsole();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerTwo.Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" | ");
            playerTwo.PrintValueOfHandToConsole();
            Console.Write(" | ");
            Console.ResetColor();
            playerTwo.PrintHandToConsole();
            Console.WriteLine();
        }
    }
}

