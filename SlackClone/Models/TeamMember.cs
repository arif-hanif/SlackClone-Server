using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlackClone.Models
{
    public class TeamMember
    {
        [Key]
        public string TeamName { get; set; }
        public Team Team { get; set; }
        [Key]
        public string MemberEmail { get; set; }
        public User Member { get; set; }

    }
}
