using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCouch;
using Newtonsoft.Json;
using performanceTest.Models;

namespace performanceTest {
    class CouchDb : IDatabase {

        MyCouchClient client;

        public CouchDb(string url, string Dbname, string Tablename) {
            this.Dbname = Dbname;
            this.Tablename = Tablename;
            client = new MyCouchClient(url, Dbname);
        }

        public string Dbname { get; set; }
        public string Tablename { get; set; }
        public void ClearDb(){
        }

        public void FillDb(int amount){
        }

        public void CreateDb(){
        }

        public void ManyJoins(){
        }

        public void ManySmallQuerys(){
        }

        public void ForceZboSpecific(){
        }

        public void ForceZboZorgvoorwaarden() {
            throw new NotImplementedException();
        }

        public void IndexedSearch(){
        }

        public void NoIndexSearch(){
        }

        public void EmbeddedVsJoin(){
        }

        public void Create(){
            var json = JsonConvert.SerializeObject(new Person());

            client.Documents.PostAsync(json);
        }

        public void Read(){
            
        }

        public void Update(){
        }

        public void Delete(){
        }
    }
}
