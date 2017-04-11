using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogEenzijdigTarief : Tarief {
        

        public ZorgTogEenzijdigTarief(SqlDataReader reader2) {
            Uzovi = (short)reader2[nameof(Uzovi)];
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(Uzovi), Uzovi));
            return bsonDocument;
        }
        public virtual short Uzovi { get; set; }

        public override short discriminator => 5;
    }
}