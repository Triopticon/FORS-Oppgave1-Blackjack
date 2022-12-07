using System;
using System.Text;

namespace BlackjackConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerOneName = "Kenneth";
            string playerTwoName = "Marit";

            if (args.Length > 0)
            {
                playerOneName = args.Length >= 1 && args[0] != "" ? args[0] : playerOneName;
                playerTwoName = args.Length >= 2 && args[1] != "" ? args[1] : playerTwoName;
            }

            Console.Title = "KS81 Blackjack";

            Console.WriteLine("Velkommen til KS81 Blackjack " + Game.GetGameVersion());
            Console.WriteLine("Spiller ein: " + playerOneName);
            Console.WriteLine("Spiller to: " + playerTwoName);
            Console.WriteLine("Trykk ein knapp for å spill.");
            Console.ReadKey();
            Console.Clear();


            Game game = new(playerOneName: playerOneName, playerTwoName: playerTwoName);
            game.GameLoop();

            Console.WriteLine("\nTrykk ein knapp for å avslutte.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}