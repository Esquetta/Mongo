using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    public class BaseController:ControllerBase
    {
        protected IMongoDatabase mongoDatabase;
        public BaseController()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://sa:sa+123@cluster0.swru2ne.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase("Employees");
        }
    }
}
