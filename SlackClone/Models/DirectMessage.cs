using System;
using HotChocolate;

namespace SlackClone.Models
{
    public class DirectMessage
    {
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public Guid SenderId { get; set; }

        [GraphQLIgnore]
        public Guid RecipientId { get; set; }

        [GraphQLNonNullType]
        public string Text { get; set; }

        public DateTime Sent { get; set; }


        public DirectMessage()
        {
            
        }
    }
}
