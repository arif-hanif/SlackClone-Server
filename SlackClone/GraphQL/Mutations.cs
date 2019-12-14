using System.Threading.Tasks;
using SlackClone.Models;
using SlackClone.GraphQL.Types;
using System;
using System.Linq;
using MongoDB.Driver;
using System.Collections.Generic;

namespace SlackClone.GraphQL
{
    public class Mutations
    {
        private readonly SlackCloneDbContext _slackCloneDbContext;

        public Mutations(SlackCloneDbContext dbContext) => _slackCloneDbContext = dbContext;

        public async Task<User> CreateUser(User user)
        {
            await _slackCloneDbContext.Users.InsertOneAsync(user);

            return user;
        }

        public async Task<Channel> CreateChannel(ChannelInput channelInput)
        {
            var channel = new Channel
            {
                Name = channelInput.Name,
                Description = channelInput.Description,
                CreatedBy = channelInput.CreatedBy,
                CreatedAt = DateTime.Now
            };

            await _slackCloneDbContext.Channels.InsertOneAsync(channel);

            return channel;
        }

        public async Task<string> JoinChannel(JoinChannelInput joinChannelInput)
        {
            var filter = Builders<Channel>.Filter.Eq(x => x.Id, joinChannelInput.ChannelId);

            var channel = _slackCloneDbContext.Channels.Find(c => c.Id == joinChannelInput.ChannelId).First();

            if (channel.Members == null)
            {
                channel.Members = new List<string> { "hello" };
            }
            else
            {
                channel.Members.Add("hello");
            }

            await _slackCloneDbContext.Channels.ReplaceOneAsync(filter, channel);

            return "ok";
        }

        public async Task<ChannelMessage> CreateChannelMessage(ChannelMessage channelMessage)
        {
            await _slackCloneDbContext.ChannelMessages.InsertOneAsync(channelMessage);

            return channelMessage;
        }
    }
}
