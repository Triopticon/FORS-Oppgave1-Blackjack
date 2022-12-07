using System;
using System.Drawing;

namespace BlackjackConsoleApp
{
	public class Player
	{
		public List<Card> Hand { get; set; }
		public string Name { get; set;  }

		public Player(string name)
		{
			Name = name;
			Hand = new();
		}

		public int GetValueOfHand()
		{
			int value = 0;

			foreach (var card in Hand)
			{
				value += card.Number;
			}

			return value;
		}

		public bool IsBlackjack()
		{
			return GetValueOfHand() == Game.BlackjackValue;
		}

		public void PrintHandToConsole()
		{
			bool isFirst = true;
			foreach (var card in Hand)
            {
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
                    Console.Write(",");
                }

				card.PrintToConsoleWithColor();
            }
        }

        public void PrintValueOfHandToConsole()
        {
            Console.Write(GetValueOfHand());
        }

    }
}

