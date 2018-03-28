using PrismNewsFeed.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismNewsFeed.Services
{
    public interface IHeadlinesService
    {
        Task<List<Headline>> LoadTopHeadlines(string countryCode = "us");
        Task<List<Headline>> SearchHeadlines(string query);
    }
}
