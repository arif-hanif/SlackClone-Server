using System;
using System.Linq;
using MongoDB.Driver;
using SlackClone.Models;

namespace SlackClone.Repositories
{
    public class ChannelMessageRepository
    {
        private readonly IMongoCollection<ChannelMessage> _channelMessageCollection;

        public ChannelMessageRepository(IMongoCollection<ChannelMessage> channelMessageCollection)
        {
            _channelMessageCollection = channelMessageCollection
                ?? throw new ArgumentNullException(nameof(channelMessageCollection));
        }

        public IQueryable<ChannelMessage> GetAllMessages()
        {
            return _channelMessageCollection.AsQueryable();
        }
    }
}
