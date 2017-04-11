using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogIndividueelTarief : Tarief {
        

        public ZorgTogIndividueelTarief(SqlDataReader reader2) {
            ZorgverlenerCode = (int)reader2[nameof(ZorgverlenerCode)];
            DbcPoortspecialisme = reader2[nameof(DbcPoortspecialisme)] as short?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(ZorgverlenerCode), ZorgverlenerCode));
            bsonDocument.Add(new BsonElement(nameof(DbcPoortspecialisme), DbcPoortspecialisme));
            return bsonDocument;
        }
        public virtual short? DbcPoortspecialisme {
            get ;
            set;
        }

        public virtual int ZorgverlenerCode {
            get ;
            set;
        }

        public override short discriminator => 3;
    }
}