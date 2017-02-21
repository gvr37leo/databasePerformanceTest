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
            throw new NotImplementedException();
        }

        public void FillDb(int amount){
            throw new NotImplementedException();
        }

        public void CreateDb(){
            throw new NotImplementedException();
        }

        public void ManyJoins(){
            throw new NotImplementedException();
        }

        public void ManySmallQuerys(){
            throw new NotImplementedException();
        }

        public void ForceZboSpecific(){
            throw new NotImplementedException();
        }

        public void IndexedSearch(){
            throw new NotImplementedException();
        }

        public void NoIndexSearch(){
            throw new NotImplementedException();
        }

        public void EmbeddedVsJoin(){
            throw new NotImplementedException();
        }

        public void Create(){
            throw new NotImplementedException();
        }

        public void Read(){
            throw new NotImplementedException();
        }

        public void Update(){
            throw new NotImplementedException();
        }

        public void Delete(){
            throw new NotImplementedException();
        }
    }
}
