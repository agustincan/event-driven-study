using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Custom.Mediator.Pattern.Events
{
    public class EventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid AggregateIdentifier { get; set; }
        public string AggregateType { get; set; } = default!;
        public int Version { get; set; }
        public string EventType { get; set; } = string.Empty;
        public BaseEvent EventData { get; set; }
    }
}