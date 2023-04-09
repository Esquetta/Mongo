using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class Match
    {
        
        public ObjectId _id { get; set; }

        public string MatchName { get; set; }

        public ObjectId MvpId { get; set; }

        public  User[] User { get; set; }
    }
}
