using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlackClone.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TeamMember> Members { get; } = new List<TeamMember>();
        public List<Channel> Channels { get; } = new List<Channel>();

        public Team() { }
    }
}
