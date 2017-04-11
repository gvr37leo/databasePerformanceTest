using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogPassantenTarief : Tarief {
        

        public ZorgTogPassantenTarief(SqlDataReader reader2) {
            SoortZorgverlener = reader2[nameof(SoortZorgverlener)] as byte?;
            DbcPoortspecialisme = reader2[nameof(DbcPoortspecialisme)] as short?;
            Zorgverlenercode = reader2[nameof(Zorgverlenercode)] as int?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(SoortZorgverlener), SoortZorgverlener));
            bsonDocument.Add(new BsonElement(nameof(DbcPoortspecialisme), DbcPoortspecialisme));
            bsonDocument.Add(new BsonElement(nameof(Zorgverlenercode), Zorgverlenercode));
            return bsonDocument;
        }
        public virtual short? DbcPoortspecialisme {
            get;
            set;
        }

        public virtual int? Zorgverlenercode {
            get;
            set;
        }

        public virtual byte? SoortZorgverlener {
            get;
            set;
        }

        public override short discriminator => 9;
    }
}