using System;
using System.Text.Json;

namespace BlackjackConsoleApp
{
	public class Deck
	{
        private List<Card> _deckOfCards = new List<Card>();
        private static readonly Random rnd = new Random();

        public Card GetCard(int index)
        {
            return _deckOfCards[index];
        }

        public List<Card> GetCards()
        {
            return _deckOfCards;
        }

        public Card GetFirstCardAndRemoveIt()
        {
            Card? card = null;
            if (_deckOfCards.Count() > 0)
            {
                card = _deckOfCards[0];
                _deckOfCards.RemoveAt(0);
            }
            return card;
        }

        public void AddCard(Card card)
        {
            _deckOfCards.Add(card);
        }

        public int GetTotalNumber()
        {
            var totalNumber = 0;
            foreach (var card in _deckOfCards)
            {
                totalNumber += card.Number;
            }

            return totalNumber;
        }

        public void Initialize()
        {
            try
            {
                _deckOfCards = RESTClient.GetCardsAsync().Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not retrive deck from server.");
                Console.WriteLine("Initilizing local deck.");
                string fileName = "DeckOfCards.json";
                string jsonString = File.ReadAllText(fileName);
                _deckOfCards = JsonSerializer.Deserialize<List<Card>>(jsonString) ?? new();
                Shuffle(_deckOfCards);
            }
        }

        public List<Card> DealHand()
        {
            List<Card> hand = new();
            hand.Add(GetFirstCardAndRemoveIt());
            hand.Add(GetFirstCardAndRemoveIt());

            return hand;
        }

        public Card DrawCard()
        {
            return GetFirstCardAndRemoveIt();
        }

        private static void Shuffle(List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}

