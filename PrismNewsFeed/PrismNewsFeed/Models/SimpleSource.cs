using Newtonsoft.Json;

namespace PrismNewsFeed.Models
{
    public class SimpleSource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
