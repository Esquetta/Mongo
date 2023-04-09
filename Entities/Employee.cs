using Mongo.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class Employee
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public int __v { get; set; }
        public bool married { get; set; }
        public virtual Country country { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
