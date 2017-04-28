using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;
using performanceTest.Models;
using Raven.Abstractions.Extensions;

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
            for(int i = 0; i < amount; i++) {
                if(i % 10000 == 0) Console.WriteLine(i);
                var person = new Person();
                client.HSet(person.ID.ToString(), nameof(person.FirstMidName), person.FirstMidName);
                client.HSet(person.ID.ToString(), nameof(person.LastName), person.LastName);
            }
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
            Dictionary<string, int> foundValues = new Dictionary<string, int>();

            foreach (var tariefKey in client.LRange("tarieven.prestatiecodelijst:41", 0, -1)) {
                foundValues[tariefKey]++;
            }

            foreach (var tariefKey in client.LRange("tarieven.prestatiecodelijst:41",0,-1)) {
                foundValues[tariefKey]++;
            }

            foreach (var tariefKey in client.LRange("tarieven.dbcdeclaratiecode:190600", 0, -1)) {
                int matches = foundValues[tariefKey]++;
                if (matches == 2) {
                    client.HGetAll(tariefKey);
                }
            }


            var tarief = client.Get("tarief:xxidxx");
            
        }

        public void IndexedSearch(){
            client.HGet("1923598183555136768", "LastName");
        }

        public void NoIndexSearch(){
            int at = 0;
            List<string> results = new List<string>();
            RedisScan<string> scan;
            long cursor = 0;
            do {
                scan = client.Scan(cursor);
                cursor = scan.Cursor;
                foreach (string key in scan.Items) {
                    at++;
                    if(at % 10000 == 0) Console.WriteLine(at);
                    
                    if("ewsze" == client.HGet(key, "LastName")) {
                        results.Add(key);
                    }
                }
            } while (scan.Cursor != 0);
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
