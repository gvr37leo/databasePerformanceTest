using System.Runtime.InteropServices;
using Cassandra;

namespace performanceTest {
    class Cassandra : IDatabase{
        Cluster cluster;
        public Cassandra(){
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            

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

        public void ForceZboZorgvoorwaarden() {
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
            var session = cluster.Connect("test");
            var rs = session.Execute("insert into users (lastname, age, city, email, firstname) values ('Jones', 35, 'Austin', 'bob@example.com', 'Bob')");
        }

        public void Read(){
            var session = cluster.Connect("test");
            var rs = session.Execute("select * from users");
        }

        public void Update(){
            var session = cluster.Connect("test");
            var rs = session.Execute("update users set age = 36 where lastname = 'Jones'");
        }

        public void Delete(){
            throw new System.NotImplementedException();
        }
    }
}
