using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mssql2Mongo {
    class Mongo {
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> TogCollection;

        public Mongo(){
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("MongoForce");
            TogCollection = database.GetCollection<BsonDocument>("TogTariefWereld");
        }

        public void insert(BsonDocument doc){
            TogCollection.InsertOne(doc);
        }
    }
}
