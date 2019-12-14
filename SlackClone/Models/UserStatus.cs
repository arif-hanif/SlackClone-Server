using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlackClone.Models
{
    public class UserStatus
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
}
