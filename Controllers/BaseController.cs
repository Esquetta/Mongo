using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    public class BaseController:ControllerBase
    {
        protected IMongoDatabase mongoDatabase;
        public BaseController()
        {
            var settings = MongoClientSettings.FromConnectionString("YOUR_MONGO_LINK");
            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase("Employees");
        }
    }
}
