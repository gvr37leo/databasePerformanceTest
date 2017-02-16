using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCouch;

namespace performanceTest {
    class CouchDb : IDatabase {

        public CouchDb(string url){
            var client = new MyCouchClient(url, "test");
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
