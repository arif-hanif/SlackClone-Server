namespace SlackClone.GraphQL.Types
{
    public class ChannelMessageInput
    {
        public string ChannelId { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
    }
}
