using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace PrismNewsFeed.Models
{
    public class Headline
    {
        [JsonProperty("source")]
        public SimpleSource Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlToImage")]
        public string ImageUrl { get; set; }

        [JsonProperty("publishedAt")]
        public string PublishedAt { get; set; }

        [JsonIgnore]
        public string PublishedFormatted {
            get => Regex.Replace(PublishedAt, "[A-Za-z ]", " ");
        }

        [JsonIgnore]
        public string AuthorSource
        {
            get
            {
                if (Author != null && Author != string.Empty && Source != null && Author != string.Empty) return $"{Author}, {Source.Name}";
                else if (Author != null && Author != string.Empty) return Author;
                else return Source.Name;
            }
        }
    }
}
