using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlackClone.Models
{
    public class DirectMessage
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Content { get; set; }
        public ObjectId AuthoId { get; set; }
        public ObjectId ReceiverId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}