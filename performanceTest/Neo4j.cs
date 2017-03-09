using System;
using Neo4j.Driver.V1;

namespace performanceTest {
    class Neo4J : IDatabase {

        public IDriver driver;
        public ISession session;

        public Neo4J(string url, string Dbname, string Tablename) {
            driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "$RF5tg^YH"));
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
                session.Run($"CREATE(handle:{Tablename} {{name:paul}})");
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

        public void IndexedSearch(){
            
        }

        public void NoIndexSearch(){
            
        }

        public void EmbeddedVsJoin(){
            
        }

        public void Create(){
            session.Run($"CREATE(handle:{Tablename} {{name:'paul'}})");
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
