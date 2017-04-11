using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    class ZorgTogAfgeleidNietGecontracteerdTarief:Tarief {

        public ZorgTogAfgeleidNietGecontracteerdTarief(SqlDataReader reader2){
            Uzovi = (short)reader2[nameof(Uzovi)];
            SoortZorgverlener = reader2[nameof(SoortZorgverlener)] as byte?;
            DekkingsCode = reader2[nameof(DekkingsCode)] as string;
            Percentage = reader2[nameof(Percentage)] as int?;
        }

        public virtual short Uzovi { get; set; }

        public virtual byte? ZorgvoorwaardeProductTypeByte { get; set; }
        
        public virtual byte? SoortZorgverlener { get; set; }
        
        public virtual string DekkingsCode { get; set; }
        
        public virtual int? Percentage { get; set; }
        public override short discriminator => 16;
        public override BsonDocument completeJSON(BsonDocument bsonDocument){
            bsonDocument.Add(new BsonElement(nameof(Uzovi), Uzovi));
            bsonDocument.Add(new BsonElement(nameof(SoortZorgverlener), SoortZorgverlener));
            bsonDocument.Add(new BsonElement(nameof(DekkingsCode), DekkingsCode ?? ""));
            bsonDocument.Add(new BsonElement(nameof(Percentage), Percentage));
            return bsonDocument;
        }
    }
}
