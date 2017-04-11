using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogLandelijkTarief : Tarief {
        

        public ZorgTogLandelijkTarief(SqlDataReader reader2) {
            DbcPoortspecialisme = reader2[nameof(DbcPoortspecialisme)] as short?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(DbcPoortspecialisme), DbcPoortspecialisme));
            return bsonDocument;
        }
        public virtual short? DbcPoortspecialisme {
            get;
            set;
        }

        public override short discriminator => 2;
    }
}