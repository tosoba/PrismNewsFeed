using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PrismNewsFeed.Models;

namespace PrismNewsFeed.Services
{
    public class HeadlinesService : IHeadlinesService
    {
        private static readonly string apiKey = "2605e31a2d8a4404bd971f81cb189ba8";
        private static readonly string topHeadlinesBaseUrl = "https://newsapi.org/v2/top-headlines";
        private static readonly string queryHeadlinesBaseUrl = "https://newsapi.org/v2/everything";

        public async Task<List<Headline>> SearchHeadlines(string query)
        {
            using (var client = new HttpClient())
            {
                string contents = await client.GetStringAsync($"{queryHeadlinesBaseUrl}?q={query}&sortBy=publishedAt&apiKey={apiKey}");
                var response = JsonConvert.DeserializeObject<HeadlinesResponse>(contents);
                return response.Headlines;
            }
        }

        public async Task<List<Headline>> LoadTopHeadlines(string countryCode)
        {
            using (var client = new HttpClient())
            {
                string contents = await client.GetStringAsync($"{topHeadlinesBaseUrl}?country={countryCode}&apiKey={apiKey}");
                var response = JsonConvert.DeserializeObject<HeadlinesResponse>(contents);
                return response.Headlines;
            }
        }
    }
}
