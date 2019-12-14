using MongoDB.Driver;

namespace SlackClone.Models
{
    public class SlackCloneDbContext
    {
        private readonly IMongoDatabase _db;

        public SlackCloneDbContext(IMongoClient client, string dbName)
        {
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<ChannelMessage> ChannelMessages =>
            _db.GetCollection<ChannelMessage>("channelMessages");

        public IMongoCollection<User> Users =>
            _db.GetCollection<User>("users");

        public IMongoCollection<Channel> Channels =>
            _db.GetCollection<Channel>("channels");
    }
}
