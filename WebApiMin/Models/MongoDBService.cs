
using MongoDB.Driver;

namespace WebApiMin.Models
{
    public class MongoDBService
    {
        readonly IMongoDatabase _database;
        public MongoDBService()
        {
            MongoClient client = new(@"mongodb://localhost:27017");
            _database = client.GetDatabase("IstkaFullData");
        }
        public IMongoCollection<T> GetCollection<T>() =>
            _database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }
}
