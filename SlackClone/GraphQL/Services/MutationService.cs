using SlackClone.Models;
using SlackClone.GraphQL.Types;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace SlackClone.GraphQL
{
    public class MutationService
    {
        private readonly SlackCloneDbContext _slackCloneDbContext;

        public MutationService(SlackCloneDbContext dbContext) => _slackCloneDbContext = dbContext;

        public async Task<string> SignIn(UserInput userInput)
        {
            var user = new User
            {
                DisplayName = userInput.DisplayName
            };

            await _slackCloneDbContext.Users.InsertOneAsync(user);

            return "ok";
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

        public async Task<string> JoinChannel(JoinLeaveChannelInput joinChannelInput)
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

        public async Task<string> LeaveChannel(JoinLeaveChannelInput leaveChannelInput)
        {
            var message = "ok";

            var filter = Builders<Channel>.Filter.Eq(x => x.Id, leaveChannelInput.ChannelId);

            var channel = _slackCloneDbContext.Channels.Find(c => c.Id == leaveChannelInput.ChannelId).First();

            if (channel.Members == null)
            {
                message = "you are not part of channel";
                return message;
            }

            channel.Members.Remove("hello");

            await _slackCloneDbContext.Channels.ReplaceOneAsync(filter, channel);

            return "ok";
        }

        public async Task<ChannelMessage> CreateChannelMessage(ChannelMessageInput channelMessageInput)
        {
            var channelMessage = new ChannelMessage
            {
                ChannelId = channelMessageInput.ChannelId,
                Content = channelMessageInput.Content,
                CreatedAt = DateTime.Now,
                CreatedBy = channelMessageInput.CreatedBy
            };

            await _slackCloneDbContext.ChannelMessages.InsertOneAsync(channelMessage);

            return channelMessage;
        }
    }
}
