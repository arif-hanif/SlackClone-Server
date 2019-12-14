using System;
namespace SlackClone.Models
{
    public class SlackCloneDatabaseSettings : ISlackCloneDatabaseSettings
    {
        public string DirectMessageCollectionName { get; set; } = "directMessages";
        public string UserCollectionName { get; set; } = "users";
        public string ChannelCollectionName { get; set; } = "channels";
        public string ChannelMessageCollectionName { get; set; } = "channelMessages";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISlackCloneDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
