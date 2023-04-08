using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Order : BaseController
    {
        IMongoDatabase mongoDatabase;
        public Order()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://sa:sa+123@cluster0.swru2ne.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase("Employees");
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {

            var items = mongoDatabase.GetCollection<Orders>("Orders");
            var filter = Builders<Orders>.Filter.Empty;
            var documents = await items.Find(filter).ToListAsync();
            List<Orders> result = new List<Orders>();
            foreach (var item in documents)
            {
                result.Add(item);
            }

            return Ok(result);
        }

    }
}
