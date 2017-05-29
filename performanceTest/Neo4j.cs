using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using performanceTest.Models;

namespace performanceTest {
    class Neo4J : IDatabase {

        public IDriver driver;
        public ISession session;

        public Neo4J(string url, string Dbname, string Tablename) {
            driver = GraphDatabase.Driver(url, AuthTokens.Basic("neo4j", "$RF5tg^YH"));
            session = driver.Session();
            this.Dbname = Dbname;
            this.Tablename = Tablename;

        }

        public string Dbname { get; set; }
        public string Tablename { get; set; }

        public void ClearDb(){
            session.Run(@"
            MATCH(n)
            OPTIONAL MATCH(n) -[r] - ()
            DELETE n, r
            ");
            
        }

        public void FillDb(int amount){
            for (int i = 0; i < amount; i++) {
                Create();
            }
        }

        public void CreateDb(){
        }

        public void ManyJoins(){
            
        }

        public void ManySmallQuerys(){
            
        }

        public void ForceZboSpecific(){
            
        }

        public Task ForceZboZorgvoorwaarden() {
            throw new NotImplementedException();
        }

        public Task ForceZboZorgvoorwaarden(List<string> dekkingsCodes) {
            throw new NotImplementedException();
        }

        public void IndexedSearch(){
            IStatementResult res = session.Run("match(n:Person{name:'ywr4z'}) return n");
            
        }

        public void NoIndexSearch(){
            IStatementResult res = session.Run("match(n{ lastname: 'j1pzk'}) return n");
        }

        public void EmbeddedVsJoin(){
            
        }

        public void Create(){
            var person = new Person();
            session.Run($"CREATE(handle:Person {{name:'{person.FirstMidName}', lastname:'{person.LastName}'}})");
        }

        public void Read(){
            session.Run($"MATCH(handle:{Tablename} {{name:'paul'}}) RETURN handle");
        }

        public void Update(){
            session.Run($"MATCH(handle:{Tablename} {{name:'paul'}}) SET handle.name = 'paul'");
        }

        public void Delete(){
            session.Run($"MATCH(handle:{Tablename} {{name:paul}}) DELETE handle");
        }
    }
}
