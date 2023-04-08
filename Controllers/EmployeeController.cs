using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Entities;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var items = mongoDatabase.GetCollection<Employee>("employees");
            var filter = Builders<Employee>.Filter.Empty;
            var documents = await items.Find(filter).ToListAsync();
            List<Employee> result = new List<Employee>();
            foreach (var item in documents)
            {
                result.Add(item);
            }

            return Ok(result);
        }
    }
}
