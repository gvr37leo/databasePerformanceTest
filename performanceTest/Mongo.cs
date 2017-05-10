using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using performanceTest.Models;

namespace performanceTest {
    class Mongo : IDatabase {

        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        BsonClassMap classMap;

        public string Dbname { get; set; }
        public string Tablename { get; set; }

        public Mongo(string url, string Dbname, string Tablename) {
            this.Dbname = Dbname;
            this.Tablename = Tablename;
            BsonClassMap.RegisterClassMap<Person>();

            client = new MongoClient(url);
            database = client.GetDatabase(Dbname);
            collection = database.GetCollection<BsonDocument>(Tablename);
            
        }

        public void ClearDb(){
            client.DropDatabase(Dbname);
        }

        public void FillDb(int amount){
            for(int i = 0; i < amount; i++) {
                collection.InsertOne(new BsonDocument{
                    {"name","paul"}
                });
            }
        }

        public void CreateDb(){
            client.GetDatabase(Dbname);
        }

        public void ManyJoins(){

        }

        public void ManySmallQuerys(){
            collection.Find(new BsonDocument{
                {"name","paul"}
            });
        }

        public void ForceZboSpecific(){
            collection.FindSync(new BsonDocument {
                {"Prestatiecodelijst", 41},
                {"DbcDeclaratiecode", "190600"}
            });
        }

        public void ForceZboZorgvoorwaarden() {
            var docs = database.GetCollection<BsonDocument>("producten").FindSync(new BsonDocument {
                { "Dekkingscode",new BsonDocument{{"$in", new BsonArray(new List<string>{"01600","01636","01640"})}} }
            });
            database.GetCollection<BsonDocument>("onderdelen").FindSync(new BsonDocument {
                {"Id",new BsonDocument{{"$in", new BsonArray(new List<int>{1,2,3})}} }
            });
        }

        public void IndexedSearch(){
            collection.FindSync(new BsonDocument{
                {"_id",ObjectId.Parse("58db7694f39e3c062c484c92")}
            });
        }

        public void NoIndexSearch(){
            collection.FindSync(new BsonDocument{
                {"LastName","t6lzs"}
            });
        }

        public void EmbeddedVsJoin(){

        }

        public void Create(){
            var person = new Person();
            collection.InsertOne(person.ToBsonDocument());
        }

        public void Read(){
            collection.Find(new BsonDocument{
                {"name","paul"}
            });
        }

        public void Update(){
            collection.UpdateOne(new BsonDocument{
                {"name","paul"}
            }, new BsonDocument{
                {"name","wouter"}
            });
        }

        public void Delete(){
            collection.DeleteOne(new BsonDocument{
                {"name","paul"}
            });
        }
    }
}
