using System;
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
            using (IDocumentSession session = store.OpenSession()) {
                for(int i = 0; i < amount; i++) {
                    session.Store(new Person());
                }
                session.SaveChanges();
            }
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
            using (IDocumentSession session = store.OpenSession()) {
                var query = session.Query<Person>()
                    .Where(person => person.LastName == "gs5hb");

                query.FirstOrDefault();
            }
        }

        public void NoIndexSearch(){
            using (IDocumentSession session = store.OpenSession()) {
                var query = session.Query<Person>()
                    .Where(person => person.FirstMidName == "4a6pe");

                var res = query.FirstOrDefault();
            }
        }

        public void EmbeddedVsJoin(){
            throw new System.NotImplementedException();
        }

        public void Create(){
            using (IDocumentSession session = store.OpenSession()) {
                session.Store(new Person());
                session.SaveChanges();
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
