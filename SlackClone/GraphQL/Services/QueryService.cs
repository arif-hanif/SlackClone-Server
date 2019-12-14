using SlackClone.Models;
using MongoDB.Driver;
using System.Linq;

namespace SlackClone.GraphQL
{
    public class QueryService
    {
        private readonly SlackCloneDbContext _slackCloneDbContext;

        public QueryService(SlackCloneDbContext dbContext) => _slackCloneDbContext = dbContext;

        public IQueryable<User> GetUsers()
        {
            return _slackCloneDbContext.Users.AsQueryable();
        }

        public IQueryable<Channel> GetChannels()
        {
            return _slackCloneDbContext.Channels.AsQueryable();
        }

        public IQueryable<ChannelMessage> GetMessages()
        {
            return _slackCloneDbContext.ChannelMessages.AsQueryable();
        }
    }
}
