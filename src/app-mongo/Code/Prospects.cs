using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Prospects {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int PropectId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public List<AddressPropect> Address { get; set; }
}
