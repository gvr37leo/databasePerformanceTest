using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogVrijTarief : Tarief {
        

        public ZorgTogVrijTarief(SqlDataReader reader2) {
            
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            return bsonDocument;
        }
        public override short discriminator => 10;
    }
}