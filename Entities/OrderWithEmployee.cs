namespace Mongo.Entities
{
    public class OrderWithEmployee
    {
        public Employee Employee { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
