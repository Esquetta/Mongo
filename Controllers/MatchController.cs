using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatchController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var items = mongoDatabase.GetCollection<Match>("Matches");
            var filter = Builders<Match>.Filter.Empty;
            var documents = await items.Find(filter).ToListAsync();
            List<Match> result = new List<Match>();
            foreach (var item in documents)
            {
                result.Add(item);
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(string matchName, string mvpId)
        {
            var items = mongoDatabase.GetCollection<Match>("Matches");

            Match match = new Match
            {
                MvpId = new MongoDB.Bson.ObjectId(mvpId),
                MatchName = matchName
            };
            await items.InsertOneAsync(match);

            return Ok(match);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string MatchId)
        {
            var items = mongoDatabase.GetCollection<Match>("Matches");
            var filter = Builders<Match>.Filter.Eq("_id", new ObjectId(MatchId));

            await items.DeleteOneAsync(filter);

            return Ok(items);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMatchDto updateMatchDto)
        {
            var items = mongoDatabase.GetCollection<Match>("Matches");
            var filter = Builders<Match>.Filter.Eq("_id", new ObjectId(updateMatchDto._id));

            var updateMatch = new Match
            {
                _id = new ObjectId(updateMatchDto._id),
                MatchName = updateMatchDto.MatchName,
                MvpId = new ObjectId(updateMatchDto.MvpId)

            };

            await items.ReplaceOneAsync(filter, updateMatch);
            return Ok(updateMatch);

        }
        [HttpGet]
        public async Task<IActionResult> GetMatch(string id)
        {
            var items = mongoDatabase.GetCollection<Match>("Matches");
            var filter = Builders<Match>.Filter.Eq("_id", new ObjectId(id));

            var item = await items.FindAsync(filter);

            return Ok(item);
        }
        [HttpGet]
        public async Task<IActionResult> GetWithMvp()
        {
            var Matches = mongoDatabase.GetCollection<Match>("Matches");
            var players = mongoDatabase.GetCollection<User>("users");

            var pipeLine = Matches.Aggregate()
                .Lookup(
                foreignCollection: players,
                localField: e => e.MvpId,
                foreignField: x => x._id,
                @as: ((Match m)=>m.User));

            var result = await pipeLine.ToListAsync();

            return Ok(result);
        }
    }
}
