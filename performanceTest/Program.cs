using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    internal class Program {
        private static void Main(string[] args) {
            string dbname = "zorgvoorwaarden";
            string tablename = "TogTariefWereld";

            List<IDatabase> dbs = new List<IDatabase>();
//            dbs.Add(new Redis("localhost", dbname, tablename));
            dbs.Add(new Mssql());
            dbs.Add(new Mongo("mongodb://localhost:27017", dbname, tablename));
            //dbs.Add(new Neo4J("bolt://localhost:7687", dbname, tablename));
            //dbs.Add(new RavenDB());

            const int repetitions = 100;
            var sw = new Stopwatch();

            foreach (var database in dbs) {
                sw.Restart();
                for (int i = 0; i < repetitions; i++) {
                    if(i % (repetitions / 10) == 0) Console.WriteLine(i);
//                    database.CreateDb();
                    //database.FillDb(1300000);
//                    database.ForceZboSpecific();
                    database.ForceZboZorgvoorwaarden();
                    //database.Create();
                    //database.NoIndexSearch();
                    //database.IndexedSearch();
                    //database.Read();
                }
                sw.Stop();
                Console.WriteLine($"database {database.GetType()} took {sw.ElapsedMilliseconds / (float)repetitions} millis on average");
            }
            

        }

    }
}
