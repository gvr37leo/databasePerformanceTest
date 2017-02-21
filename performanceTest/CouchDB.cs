using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCouch;

namespace performanceTest {
    class CouchDb : IDatabase {

        MyCouchClient client;

        public CouchDb(string url){
            client = new MyCouchClient(url, "test");
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

        public void IndexedSearch(){
        }

        public void NoIndexSearch(){
        }

        public void EmbeddedVsJoin(){
        }

        public void Create(){
        }

        public void Read(){
            
        }

        public void Update(){
        }

        public void Delete(){
        }
    }
}
