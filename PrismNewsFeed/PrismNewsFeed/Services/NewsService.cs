using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PrismNewsFeed.Models;
using PrismNewsFeed.Constants;

namespace PrismNewsFeed.Services
{
    public class NewsService : INewsService
    {
        private static readonly string baseUrl = "https://newsapi.org/v2/";
        private static readonly string topHeadlines = "top-headlines";
        private static readonly string queryEverything = "everything";
        private static readonly string sources = "sources";

        private HttpClient client;
        public HttpClient Client { get => client == null ? client = new HttpClient() : client; }

        public async Task<List<Headline>> SearchHeadlines(string query)
        {
            var contents = await Client.GetStringAsync($"{baseUrl}{queryEverything}?q={query}&sortBy=publishedAt&apiKey={Api.key}");
            var response = JsonConvert.DeserializeObject<HeadlinesResponse>(contents);
            return response.Headlines;
        }

        public async Task<List<Headline>> LoadTopHeadlines(string source)
        {
            var url = source == null ? $"{baseUrl}{topHeadlines}?country=us&apiKey={Api.key}" : $"{baseUrl}{topHeadlines}?sources={source}&apiKey={Api.key}";
            var contents =  await Client.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<HeadlinesResponse>(contents);
            return response.Headlines;
        }

        public async Task<List<Source>> LoadSources()
        {
            var contents = await Client.GetStringAsync($"{baseUrl}{sources}?apiKey={Api.key}");
            var response = JsonConvert.DeserializeObject<SourcesResponse>(contents);
            return response.Sources;
        }
    }
}
