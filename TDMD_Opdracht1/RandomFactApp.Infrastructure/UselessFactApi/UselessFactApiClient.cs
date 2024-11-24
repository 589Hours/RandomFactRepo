using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RandomFactApp.Domain.Clients;
using RandomFactApp.Domain.Models;

namespace RandomFactApp.Infrastructure.UselessFactApi
{
    public class UselessFactApiClient : IRandomFactClient
    {
        private readonly HttpClient httpClient;

        public UselessFactApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RandomFact> RetrieveRandomFactAsync(string language)
        {
            string randomFactBit = $"facts/random?language={language}";
            HttpResponseMessage response = await httpClient.GetAsync(randomFactBit);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();

            return new RandomFact() { Fact = GetFactFromJson(jsonString) };
        }

        //ik weet dat je ook het format kan mee geven aan een data klasse, maar ik had het eerst op deze manier gedaan en heb het zo gehouden.
        public string GetFactFromJson(string json)
        {
            JsonDocument jsonDoc = JsonDocument.Parse(json);
            JsonElement root = jsonDoc.RootElement;
            if (root.TryGetProperty("text", out var factElement))
            {
                return factElement.GetString();
            }

            return "We run out of facts today!";
        }
    }
}
