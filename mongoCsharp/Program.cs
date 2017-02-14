using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;


namespace mongoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            MongoClient mongo = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = mongo.GetDatabase("test");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("people");
            collection.InsertOne(new BsonDocument
                {
                    { "name", "MongoDB" },
                    { "type", "Database" },
                    { "count", 1 },
                    { "info", new BsonDocument
                        {
                            { "x", 203 },
                            { "y", 102 }
                        }}
                });
            sw.Stop();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.ReadKey();
        }
    }
}
