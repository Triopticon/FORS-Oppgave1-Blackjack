using System;
namespace BlackjackConsoleApp
{
	public class Game
	{
        private const string GameVersion = "v1.1";

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

            if (!CheckBlackjack())
            {
                bool skipPlayerTwo = false;
                while (!playerOne.IsBlackjack()
                       && playerOne.GetValueOfHand() < Game.stopDrawingCardAtValue)
                {
                    playerOne.Hand.Add(deckOfCards.DrawCard());

                    if (playerOne.GetValueOfHand() >= Game.BlackjackValue)
                    {
                        skipPlayerTwo = true;
                        break;
                    }
                }

                while (!skipPlayerTwo
                       && !playerTwo.IsBlackjack()
                       && playerTwo.GetValueOfHand() <= playerOne.GetValueOfHand())
                {
                    playerTwo.Hand.Add(deckOfCards.DrawCard());
                }
            }

            CheckBlackjack();
            WriteResultsToConsole();
        }

        private static void InitializeHands()
        {
            deckOfCards.Initialize();
            playerOne.Hand = deckOfCards.DealHand();
            playerTwo.Hand = deckOfCards.DealHand();
            playerOne.HasBlackjack = false;
            playerTwo.HasBlackjack = false;
        }

        private static bool CheckBlackjack()
        {
            bool playerOneHasBlackjack = playerOne.GetValueOfHand() == Game.BlackjackValue;
            bool playerTwoHasBlackjack = playerTwo.GetValueOfHand() == Game.BlackjackValue;

            if (playerOneHasBlackjack)
            {
                playerOne.HasBlackjack = true;
                return true;
            }
            else if (playerTwoHasBlackjack)
            {
                playerTwo.HasBlackjack = true;
                return true;
            }

            return false;
        }

        private static string CheckWinner()
        {
            if (playerOne.HasBlackjack)
            {
                return playerOne.Name;
            }
            else if (playerTwo.HasBlackjack)
            {
                return playerTwo.Name;
            }
            else if(playerTwo.GetValueOfHand() > Game.BlackjackValue)
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
            if (playerOne.HasBlackjack)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(" - Blackjack");
                Console.ResetColor();
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerTwo.Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" | ");
            playerTwo.PrintValueOfHandToConsole();
            Console.Write(" | ");
            Console.ResetColor();
            playerTwo.PrintHandToConsole();
            if (playerTwo.HasBlackjack)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(" - Blackjack");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}

