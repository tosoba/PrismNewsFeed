using PrismNewsFeed.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismNewsFeed.Services
{
    public interface ITopHeadlinesService
    {
        Task<List<Headline>> LoadTopHeadlines();
    }
}
