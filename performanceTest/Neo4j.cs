using System;
using Neo4j.Driver.V1;

namespace performanceTest {
    class Neo4J : IDatabase {

        public Neo4J(string url){
            var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "$RF5tg^YH"));
        }
       

        public void ClearDb(){
            throw new NotImplementedException();
        }

        public void FillDb(){
            throw new NotImplementedException();
        }

        public void CreateDb()
        {
            throw new NotImplementedException();
        }

        public void Create(int amount){
            throw new NotImplementedException();
        }

        public void Read(int amount){
            throw new NotImplementedException();
        }

        public void Update(int amount){
            throw new NotImplementedException();
        }

        public void Delete(int amount){
            throw new NotImplementedException();
        }
    }
}
