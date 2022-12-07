using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlackjackConsoleApp
{
	public class RESTClient
	{
        static HttpClient client = new();

        /// <summary>
        /// Internal method to set up the REST Client.
        /// </summary>
        private static void SetupRESTClient()
        {
            client.BaseAddress = new Uri("https://blackjack.labs.nais.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.DefaultRequestHeaders.Add("User-Agent", "KS81 Blackjack Client");
        }

        /// <summary>
        /// Get the array of cards from the endpoint and deserialize from JSON to an array of <see cref="Card"/> objects.
        /// </summary> 
        /// <returns>A Task with an array of <see cref="Card"/> objects</returns>
        public static async Task<List<Card>> GetCardsAsync()
        {
            SetupRESTClient();

            await using Stream stream = await client.GetStreamAsync("shuffle");

            var cards = await JsonSerializer.DeserializeAsync<List<Card>>(stream);

            //Console.Write("Cards: " + JsonSerializer.Serialize(cards, new JsonSerializerOptions() { WriteIndented = true }) + "\n\n");

            return cards ?? new();
        }
    }
}

