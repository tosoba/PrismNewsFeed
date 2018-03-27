using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PrismNewsFeed.Models;

namespace PrismNewsFeed.Services
{
    public class TopHeadlinesService : ITopHeadlinesService
    {
        private static readonly string url = "https://newsapi.org/v2/top-headlines?country=us&apiKey=2605e31a2d8a4404bd971f81cb189ba8";

        public async Task<List<Headline>> LoadTopHeadlines()
        {
            using (var client = new HttpClient())
            {
                string contents;
                contents = await client.GetStringAsync(url);
                var response = JsonConvert.DeserializeObject<HeadlinesResponse>(contents);
                return response.Headlines;
            }
        }
    }
}
