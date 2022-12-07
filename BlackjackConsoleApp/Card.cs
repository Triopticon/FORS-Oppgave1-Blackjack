using System;
using System.Text.Json.Serialization;

namespace BlackjackConsoleApp
{
    public record class Card
    (
        [property: JsonPropertyName("suit")] string Suit,
        [property: JsonPropertyName("value")] string Value
    )
    {
        public int Number => GetCardNumber(Value);

        public static int GetCardNumber(string value)
        {
            var number = 0;
            if (value != null)
            {
                switch (value)
                {
                    case "J":
                    case "Q":
                    case "K":
                        number = 10;
                        break;
                    case "A":
                        number = 11;
                        break;
                    default:
                        bool success = Int32.TryParse(value, out number);
                        if (!success)
                        {
                            number = 0;
                        }
                        break;
                }
            }

            return number;
        }

        public override string ToString()
        {
            return string.Concat(this.Suit.AsSpan(0, 1), this.Value);
        }

        public void PrintToConsole(Boolean withLineBreak = false)
        {
            if (withLineBreak)
            {
                Console.WriteLine(this);
            }
            else
            {
                Console.Write(this);
            }
        }

        public void PrintToConsoleWithColor(Boolean withLineBreak = false)
        {
            ConsoleColor color;
            switch (this.Suit)
            {
                case "HEARTS":
                case "DIAMONDS":
                    color = ConsoleColor.Red;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = color;
            PrintToConsole(withLineBreak);
            Console.ResetColor();
        }
    }
}

