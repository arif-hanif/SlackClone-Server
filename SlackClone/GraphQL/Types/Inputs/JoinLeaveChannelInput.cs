namespace SlackClone.GraphQL.Types
{
    public class JoinLeaveChannelInput
    {
        public string ChannelId { get; set; }
        public string MemberId { get; set; }
    }
}
