using Newtonsoft.Json;

namespace PrismNewsFeed.Models
{
    public class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
