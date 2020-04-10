
using System.ComponentModel.DataAnnotations;

namespace SlackClone.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Online { get; set; }
    }
}
