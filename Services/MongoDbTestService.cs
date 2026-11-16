using MongoDB.Driver;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class MongoDbTestService
    {
        private readonly IMongoDatabase database;

        public MongoDbTestService(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task TestConnection()
        {
            await database.RunCommandAsync<BsonDocument>(
            new BsonDocument("ping", 1)
            );
        }
    }
}
