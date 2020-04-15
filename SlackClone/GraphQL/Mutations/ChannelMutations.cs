using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SlackClone.Models;

namespace SlackClone.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ChannelMutations
    {
        //[Authorize]
        public async Task<CreateMutationResponse<Channel>> CreateChannel(
            CreateChannelInput input,
            [Service]SlackCloneDbContext dbContext,
            CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(input.Name))
                {
                    throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The channel name can not be null.")
                        .SetCode("INVALID_INPUT")
                        .Build());
                }

                var channel = new Channel()
                {
                    Name = input.Name,
                    Description = input.Description
                };

                dbContext.Channels.Add(channel);
                await dbContext.SaveChangesAsync(cancellationToken);
                bool ok = true;
                return new CreateMutationResponse<Channel>(ok, channel);
            }
            catch (DbUpdateException e)
            {
                throw new QueryException($"DbUpdateException error details - {e?.InnerException?.Message}");
            }
        }

        public async Task<string> AddMessageToChannel(
            AddMessageToChannelInput input,
            [GlobalState]string currentUserEmail,
            [Service]SlackCloneDbContext dbContext,
            [Service]ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {

            var message = new ChannelMessage
            {
                Id = Guid.NewGuid(),
                Text = input.Text,
                CreatedAtUTC = DateTime.UtcNow
            };

            dbContext.ChannelMessages.Add(message);
            await dbContext.SaveChangesAsync(cancellationToken);

            return "ok";
        }

    }
}
