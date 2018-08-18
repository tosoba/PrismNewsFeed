using PrismNewsFeed.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrismNewsFeed
{
    public static class Database
    {
        private static readonly string dbName = "newsDb";

        private static readonly string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

        public static void InitDb()
        {
            var db = new SQLiteConnection(path);
            db.CreateTable<SavedQuery>();
        }

        public static void InsertOrUpdateQuery(SavedQuery query)
        {
            var db = new SQLiteConnection(path);
            var saved = db.Query<SavedQuery>("select * from SavedQuery where Query = ?", query.Query);
            if (saved.Any())
            {
                db.Update(query);
            }
            else
            {
                db.Insert(query);
            }
        }

        public static List<SavedQuery> GetQueries()
        {
            var db = new SQLiteConnection(path);
            return db.Query<SavedQuery>("select * from SavedQuery").OrderByDescending(q => q.LastSearched).ToList();
        }
    }
}
