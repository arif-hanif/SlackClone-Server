using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlackClone.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Online { get; set; }
    }
}
