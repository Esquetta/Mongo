using MongoDB.Bson;

namespace Mongo.Dtos
{
    public class UpdateMatchDto
    {
        public string _id { get; set; }

        public string MatchName { get; set; }

        public string MvpId { get; set; }
    }
}
