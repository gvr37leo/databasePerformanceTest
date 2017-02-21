using System;
using Neo4j.Driver.V1;

namespace performanceTest {
    class Neo4J : IDatabase {

        public IDriver driver;

        public Neo4J(string url){
            driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "$RF5tg^YH"));
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
