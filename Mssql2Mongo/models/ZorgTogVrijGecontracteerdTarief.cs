﻿using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogVrijGecontracteerdTarief : Tarief {
        

        public ZorgTogVrijGecontracteerdTarief(SqlDataReader reader2) {
            Uzovi = reader2[nameof(Uzovi)] as short?;
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(Uzovi), Uzovi));
            bsonDocument.Add(new BsonElement(nameof(ZorgverlenerCode), ZorgverlenerCode));
            bsonDocument.Add(new BsonElement(nameof(Contractnummer), Contractnummer));
            return bsonDocument;
        }
        public virtual short? Uzovi { get; set; }

        
        public virtual int? ZorgverlenerCode { get; set; }

        
        public virtual long? Contractnummer { get; set; }

        public override short discriminator => 17;
    }
}