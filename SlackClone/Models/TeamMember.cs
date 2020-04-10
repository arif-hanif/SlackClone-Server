using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlackClone.Models
{
    public class TeamMember
    {
        [Key]
        public string TeamName { get; set; }
        public string Member { get; set; }
    }
}
