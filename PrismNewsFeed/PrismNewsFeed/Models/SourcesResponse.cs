using Newtonsoft.Json;
using System.Collections.Generic;

namespace PrismNewsFeed.Models
{
    public class SourcesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }
    }
}
