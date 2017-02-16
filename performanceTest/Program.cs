using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    class Program {
        static void Main(string[] args) {
            IDatabase mssql = new Mssql();
            IDatabase mongo = new Mongo("mongodb://localhost:27017");
            IDatabase neo4J = new Neo4J("bolt://localhost:7687");
            IDatabase couchDb = new CouchDb();
            IDatabase[] dbs = {mssql, mongo, neo4J, couchDb};
            int repetitions = 10;
            var sw = new Stopwatch();

            foreach (IDatabase database in dbs){
                sw.Restart();
                foreach (int i in Enumerable.Range(0, 100000000))
                {
                    
                }
                //database.Read(repetitions);
                sw.Stop();
                Console.WriteLine($"database {database.GetType()} took {sw.ElapsedMilliseconds / repetitions} millis on average");
            }
        }
    }
}
