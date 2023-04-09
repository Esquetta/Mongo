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
        [HttpGet]
        public async Task<IActionResult> GetEmployeeWithOrders()
        {
            var employees = mongoDatabase.GetCollection<Employee>("employees");
            var orders = mongoDatabase.GetCollection<Orders>("Orders");

            var pipeLine = employees.Aggregate().Lookup(
                foreignCollection: orders,
                localField: e => e.id,
                foreignField: x => x.employeeId,
                @as: (Employee e) => e.Orders);

            var result = await pipeLine.ToListAsync();

            return Ok(result);

        }
    }
}
