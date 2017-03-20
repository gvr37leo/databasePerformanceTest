using System.Linq;
using performanceTest.Models;
using Raven;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Linq;

namespace performanceTest {
    class RavenDB : IDatabase{
        IDocumentStore store;

        public RavenDB(){
            store = new DocumentStore {
                Url = "http://localhost:8080/", // server URL
                DefaultDatabase = "test"	// default database
            };
            store.Initialize();

           
        }

        public string Dbname { get; set; }
        public string Tablename { get; set; }
        public void ClearDb(){
            throw new System.NotImplementedException();
        }

        public void FillDb(int amount){
            throw new System.NotImplementedException();
        }

        public void CreateDb(){
            throw new System.NotImplementedException();
        }

        public void ManyJoins(){
            throw new System.NotImplementedException();
        }

        public void ManySmallQuerys(){
            throw new System.NotImplementedException();
        }

        public void ForceZboSpecific(){
            throw new System.NotImplementedException();
        }

        public void IndexedSearch(){
            throw new System.NotImplementedException();
        }

        public void NoIndexSearch(){
            throw new System.NotImplementedException();
        }

        public void EmbeddedVsJoin(){
            throw new System.NotImplementedException();
        }

        public void Create(){
            using (IDocumentSession session = store.OpenSession()) {
                Person person = new Person {
                    FirstMidName = "John",
                    LastName = "baap"
                };

                session.Store(person);
                string employeeId = person.Id;

                session.SaveChanges();

                Person loadedPerson = session.Load<Person>(employeeId);
            }
        }

        public void Read(){
            using (var session = store.OpenSession()) {

                var query =
                    from person in session.Query<Person>()
                    select person;
                var result = query.ToList();

            }
        }

        public void Update(){
            throw new System.NotImplementedException();
        }

        public void Delete(){
            throw new System.NotImplementedException();
        }
    }
}
