using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace performanceTest{
    class Redis:IDatabase {

        RedisClient client;

        public Redis(string url, string Dbname, string Tablename) {
            this.Dbname = Dbname;
            this.Tablename = Tablename;
            client = new RedisClient(url);
        }

        public string Dbname { get; set; }
        public string Tablename { get; set; }
        public void ClearDb(){
            client.FlushDb();
        }

        public void FillDb(int amount){
            //n.v.t
        }

        public void CreateDb(){
            //n.v.t
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
            client.Set("name", "paul");
        }

        public void Read(){
            client.Get("name");
        }

        public void Update(){
            client.Set("name", "paul");
        }

        public void Delete(){
            client.Del("name");
        }
    }
}
