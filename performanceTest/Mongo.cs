using System;

namespace performanceTest {
    class Mongo : IDatabase {

        public Mongo(string url){
            MongoClient mongo = new MongoClient(url);
        }

        public void ClearDb() {
            throw new NotImplementedException();
        }

        public void FillDb() {
            throw new NotImplementedException();
        }

        public void CreateDb()
        {
            throw new NotImplementedException();
        }

        public void Create(int amount) {
            throw new NotImplementedException();
        }

        public void Read(int amount) {
            throw new NotImplementedException();
        }

        public void Update(int amount) {
            throw new NotImplementedException();
        }

        public void Delete(int amount) {
            throw new NotImplementedException();
        }
    }
}
