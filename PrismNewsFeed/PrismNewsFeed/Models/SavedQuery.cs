using SQLite;
using System;

namespace PrismNewsFeed.Models
{
    public class SavedQuery
    {
        [PrimaryKey]
        public string Query { get; set; }
        public DateTime LastSearched { get; set; }
    }
}
