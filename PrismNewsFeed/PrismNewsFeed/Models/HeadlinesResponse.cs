using Newtonsoft.Json;
using System.Collections.Generic;

namespace PrismNewsFeed.Models
{
    public class HeadlinesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("articles")]
        public List<Headline> Headlines { get; set; }
    }
}
