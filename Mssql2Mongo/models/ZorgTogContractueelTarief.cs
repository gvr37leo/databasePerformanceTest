using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mssql2Mongo.models {
    class ZorgTogContractueelTarief : Tarief{

        public ZorgTogContractueelTarief(SqlDataReader reader2){
            Uzovi = reader2[nameof(Uzovi)] as short?;
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
            TypeZorgverlenerString = reader2[nameof(TypeZorgverlenerString)] as char?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(Uzovi), Uzovi));
            bsonDocument.Add(new BsonElement(nameof(ZorgverlenerCode), ZorgverlenerCode));
            bsonDocument.Add(new BsonElement(nameof(Contractnummer), Contractnummer));
            bsonDocument.Add(new BsonElement(nameof(TypeZorgverlenerString), TypeZorgverlenerString));
            return bsonDocument;
        }
        public virtual long? Contractnummer { get; set; }
        
        public virtual short? Uzovi { get; set; }
        
        public virtual int? ZorgverlenerCode { get; set; }
        
        public virtual char? TypeZorgverlenerString { get; set; }

        public override short discriminator => 4;
    }
}
