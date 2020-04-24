using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using SlackClone.Models;

namespace SlackClone.GraphQL.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class MessageSubscriptions
    {
        [SubscribeAndResolve]
        public async Task<IAsyncEnumerable<ChannelMessage>> OnMessageReceivedAsync(
            [GlobalState]string currentUserEmail,
            [Service]ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, ChannelMessage>(
                currentUserEmail, cancellationToken);
        }
    }
}
