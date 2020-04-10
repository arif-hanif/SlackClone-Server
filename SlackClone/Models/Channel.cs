using System;
using System.Collections.Generic;

namespace SlackClone.Models
{
    public class Channel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int MemberCount { get => Members.Count; }
        public List<TeamMember> Members { get; set; }
        public List<ChannelMessage> Messages { get; set; }
    }
}