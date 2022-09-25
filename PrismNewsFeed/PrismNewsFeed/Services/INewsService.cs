using PrismNewsFeed.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismNewsFeed.Services
{
    public interface INewsService
    {
        Task<List<Headline>> LoadTopHeadlines(string source = null);
        Task<List<Headline>> SearchHeadlines(string query);
        Task<List<Source>> LoadSources();
    }
}
