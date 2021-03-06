﻿using System.Data.SqlClient;
using MongoDB.Bson;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogIndividueelSluittarief : Tarief {
        

        public ZorgTogIndividueelSluittarief(SqlDataReader reader2) {
            ZorgverlenerCode = (int)reader2[nameof(ZorgverlenerCode)];
            SoortZorgverlener = reader2[nameof(SoortZorgverlener)] as byte?;
        }
        public override BsonDocument completeJSON(BsonDocument bsonDocument) {
            bsonDocument.Add(new BsonElement(nameof(ZorgverlenerCode), ZorgverlenerCode));
            bsonDocument.Add(new BsonElement(nameof(SoortZorgverlener), SoortZorgverlener));
            return bsonDocument;
        }
        public virtual int ZorgverlenerCode {
            get;
            set;
        }

        
        public virtual byte? SoortZorgverlener {
            get;
            set;
        }
        public override short discriminator => 8;
    }
}