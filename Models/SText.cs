
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreTextAPI.Models;

public class SText
{
    // public string? id { get; set; }

    // [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string url { get; set; } = null!;

    public string filename { get; set; } = null!;

    public string textdata { get; set; } = null!;
}