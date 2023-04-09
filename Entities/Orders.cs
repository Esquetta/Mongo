using MongoDB.Bson;

namespace Mongo.Entities
{
    public class Orders
    {
        public ObjectId _id { get; set; }
        public int employeeId { get; set; }
        public int orderId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
