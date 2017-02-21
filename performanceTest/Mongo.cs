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
        }

        public void IndexedSearch(){
        }

        public void NoIndexSearch(){
        }

        public void EmbeddedVsJoin(){
        }

        public void Create(){
            collection.InsertOne(new BsonDocument{
                {"name","paul"}
            });
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
