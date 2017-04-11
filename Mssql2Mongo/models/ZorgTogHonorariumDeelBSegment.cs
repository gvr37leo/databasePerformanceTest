using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogHonorariumDeelBSegment : Tarief {
        

        public ZorgTogHonorariumDeelBSegment(SqlDataReader reader2) {
                
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            return bsonDocument;
        }
        public override short discriminator => 14;
    }
}