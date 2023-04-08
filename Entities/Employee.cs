using MongoDB.Bson;

namespace Mongo.Entities
{
    public class Employee
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public int __v { get; set; }
        public bool married { get; set; }
        public Country country { get; set; }
    }
}
