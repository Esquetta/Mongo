using MongoDB.Bson;

namespace Mongo.Dtos
{
    public class UpdateUserDto
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public bool Married { get; set; }
        public string Address { get; set; }
    }
}
