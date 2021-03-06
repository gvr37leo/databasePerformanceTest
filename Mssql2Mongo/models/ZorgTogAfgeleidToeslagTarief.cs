﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mssql2Mongo.models {
    class ZorgTogAfgeleidToeslagTarief : Tarief {

        public ZorgTogAfgeleidToeslagTarief(SqlDataReader reader2){
            Uzovi = (short)reader2[nameof(Uzovi)];
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(Uzovi), Uzovi));
            bsonDocument.Add(new BsonElement(nameof(ZorgverlenerCode), ZorgverlenerCode));
            return bsonDocument;
        }
        public override short discriminator => 19;

        public virtual short Uzovi { get; set; }

        public virtual int? ZorgverlenerCode { get; set; }
    }
}
