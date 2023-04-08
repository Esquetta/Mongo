using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var items = mongoDatabase.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Empty;
            var documents = await items.Find(filter).ToListAsync();
            List<User> result = new List<User>();
            foreach (var item in documents)
            {
                result.Add(item);
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var items = mongoDatabase.GetCollection<User>("users");
            await items.InsertOneAsync(user);

            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto user)
        {
            var items = mongoDatabase.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("_id", new ObjectId(user._id));
            //If we want to update with object

            var updatedUser = new User
            {
                _id = new ObjectId(user._id),
                Name = user.Name,
                SurName = user.SurName,
                Age = user.Age,
                Married = user.Married,
                Address = user.Address,

            };
            await items.ReplaceOneAsync(filter, updatedUser);

            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var items = mongoDatabase.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("_id", new ObjectId(Id));

            await items.DeleteOneAsync(filter);

            return Ok(items);

        }
    }

}
