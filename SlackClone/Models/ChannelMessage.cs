using System;

namespace SlackClone.Models
{
    public class ChannelMessage
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public Guid? ThreadId { get; set; }
    }
}
