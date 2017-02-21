using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    internal class Program {
        private static void Main(string[] args) {
            string dbname = "performanceTest";
            string tablename = "performanceTest";

            IDatabase mssql = new Mssql();
            IDatabase mongo = new Mongo("mongodb://localhost:27017", dbname, tablename);
            IDatabase neo4J = new Neo4J("bolt://localhost:7687");
            IDatabase couchDb = new CouchDb("http://localhost:5984/");
            IDatabase[] dbs = {mssql, mongo, neo4J, couchDb};

            const int repetitions = 10;
            var sw = new Stopwatch();

            foreach (var database in dbs){
                sw.Restart();
                for(int i = 0; i < repetitions; i++) {
                    database.Read();
                }
                sw.Stop();
                Console.WriteLine($"database {database.GetType()} took {sw.ElapsedMilliseconds / repetitions} millis on average");
            }
        }
    }
}
