using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PrismNewsFeed.Models;
using System.Net.Http.Headers;

namespace PrismNewsFeed.Services
{
    public class NewsService : INewsService
    {
        private static readonly string baseUrl = "https://newsapi.org/v2/";
        private static readonly string topHeadlines = "top-headlines";
        private static readonly string queryEverything = "everything";
        private static readonly string sources = "sources";

        private HttpClient client;
        public HttpClient Client
        {
            get
            {
                if (client != null) return client;
                client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PrismNewsFeed", "1.0"));
                return client;
            }
        }

        public async Task<List<Headline>> SearchHeadlines(string query)
        {
            var msg = await Client.GetAsync($"{baseUrl}{queryEverything}?q={query}&sortBy=publishedAt&apiKey={Api.key}");
            var content = await msg.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<HeadlinesResponse>(content);
            return response.Headlines;
        }

        public async Task<List<Headline>> LoadTopHeadlines(string source)
        {
            var url = source == null ? $"{baseUrl}{topHeadlines}?country=us&apiKey={Api.key}" : $"{baseUrl}{topHeadlines}?sources={source}&apiKey={Api.key}";
            var msg =  await Client.GetAsync(url);
            var content = await msg.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<HeadlinesResponse>(content);
            return response.Headlines;
        }

        public async Task<List<Source>> LoadSources()
        {
            var msg = await Client.GetAsync($"{baseUrl}{sources}?apiKey={Api.key}");
            var content = await msg.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<SourcesResponse>(content);
            return response.Sources;
        }
    }
}
