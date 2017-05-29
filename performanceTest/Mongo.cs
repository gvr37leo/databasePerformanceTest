using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NHibernate.Util;
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

        public async Task ForceZboZorgvoorwaarden() {
            await ForceZboZorgvoorwaarden(new List<string> {"01600", "01636", "01640"});
        }

        public async Task ForceZboZorgvoorwaarden(List<string> dekkingsCodes) {
//            var onderdeelids = db.getCollection('producten').distinct("ProductInstanties.Onderdelen",{ "CommercieleProducten.Dekkingen.Dekkingscode":{$in:['01600', '01636', '01640']
//                }
//            })
//
//            db.onderdelen.distinct("details._id",{"_id":{$in:onderdeelids}})
            var doc = database.GetCollection<BsonDocument>("producten")
                .Distinct<long>("ProductInstanties.Onderdelen", new BsonDocument {
                    {
                        "CommercieleProducten.Dekkingen.Dekkingscode",
                        new BsonDocument {
                            {"$in", new BsonArray(dekkingsCodes)}
                        }
                    }
                });
            await doc.MoveNextAsync();
            var onderdelenids = doc.Current;

            var x = await database.GetCollection<BsonDocument>("onderdelen").FindAsync(new BsonDocument {
                {"_id",new BsonDocument{{"$in", new BsonArray(onderdelenids)}} }
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
