using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    internal class Program {
        private static Random rng = new Random();

        private static void Main(string[] args) {
            string dbname = "zorgvoorwaarden";
            string tablename = "TogTariefWereld";
            

            List<IDatabase> dbs = new List<IDatabase>();
//            dbs.Add(new Redis("localhost", dbname, tablename));
            dbs.Add(new Mssql());
            dbs.Add(new Mongo("mongodb://localhost:27017", dbname, tablename));
            //dbs.Add(new Neo4J("bolt://localhost:7687", dbname, tablename));
            //dbs.Add(new RavenDB());
            
            var sw = new Stopwatch();

            long sql = 0;
            long mongo = 0;
            long sqlsame = 0;
            long mongosame = 0;


            var tasks = Enumerable.Range(0, 100)
                .Select(async j => {
                    List<string> randomDekkingsCodes = new List<string>();
                    int numberOfDekkingsCodes = rng.Next(1, 5);
                    for (int i = 0; i < numberOfDekkingsCodes; i++) {
                        randomDekkingsCodes.Add(dekkingscodes[rng.Next(0, dekkingscodes.Count)]);
                    }

                    sql += await Time(() => dbs[0].ForceZboZorgvoorwaarden(randomDekkingsCodes));
                    mongo += await Time(() => dbs[1].ForceZboZorgvoorwaarden(randomDekkingsCodes));

                    sqlsame += await Time(() => dbs[0].ForceZboZorgvoorwaarden());
                    mongosame += await Time(() => dbs[1].ForceZboZorgvoorwaarden());
                });

            Task.WhenAll(tasks).Wait();
            
            Console.WriteLine($"sql took {sql} millis");
            Console.WriteLine($"mongo took {mongo} millis");
            Console.WriteLine($"sqlsame took {sqlsame} millis");
            Console.WriteLine($"mongosame took {mongosame} millis");

            //            foreach (var database in dbs) {
            //                long totalTime = Repeat(repetitions, () => database.ForceZboZorgvoorwaarden(TODO));
            //                Console.WriteLine($"database {database.GetType()} took {totalTime / (float)repetitions} millis on average");
            //                database.CreateDb();
            //                database.FillDb(1300000);
            //                                    database.ForceZboSpecific();
            //                Time(database.ForceZboZorgvoorwaarden);
            //                database.ForceZboZorgvoorwaarden();
            //                database.Create();
            //                database.NoIndexSearch();
            //                database.IndexedSearch();
            //                database.Read();

            //            }

            Console.ReadLine();
            Console.ReadLine();

        }


        private static async Task<long> Repeat(int repetitions, Func<Task> action) {
            long totalTime = 0;
            for (int i = 0; i < repetitions; i++) {
                if (i % (repetitions / 10) == 0) Console.WriteLine(i);
                totalTime += await Time(action);
            }
            return totalTime;
        }

        private static async Task<long> Time(Func<Task> action) {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            await action();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static List<string> dekkingscodes = new List<string> {
            "01120",
            "01141",
            "01142",
            "01143",
            "01240",
            "01241",
            "01242",
            "01250",
            "01251",
            "01252",
            "01253",
            "01254",
            "01255",
            "01256",
            "01257",
            "01260",
            "01261",
            "01262",
            "01263",
            "01264",
            "01265",
            "01266",
            "01267",
            "01331",
            "01332",
            "01333",
            "01334",
            "01335",
            "01336",
            "01337",
            "01338",
            "01339",
            "01340",
            "01341",
            "01342",
            "01343",
            "01344",
            "01345",
            "01346",
            "01347",
            "01348",
            "01350",
            "01351",
            "01352",
            "01353",
            "01354",
            "01355",
            "01356",
            "01357",
            "01358",
            "01599",
            "01600",
            "01601",
            "01602",
            "01603",
            "01605",
            "01606",
            "01607",
            "01608",
            "01609",
            "01610",
            "01611",
            "01612",
            "01613",
            "01614",
            "01615",
            "01616",
            "01617",
            "01618",
            "01619",
            "01620",
            "01622",
            "01624",
            "01626",
            "01627",
            "01628",
            "01629",
            "01630",
            "01631",
            "01635",
            "01636",
            "01637",
            "01638",
            "01639",
            "01640",
            "01641",
            "01642",
            "01643",
            "01644",
            "01645",
            "01646",
            "01649",
            "01650",
            "01651",
            "01652",
            "01653",
            "01654",
            "01655",
            "01656",
            "01657",
            "01658",
            "01659",
            "01666",
            "01667",
            "01668",
            "01669",
            "01670",
            "01671",
            "01681",
            "01682",
            "01683",
            "01684",
            "01685",
            "01690",
            "01691",
            "01692",
            "01693",
            "01694",
            "01695",
            "01696",
            "01697",
            "01698",
            "01699",
            "01709",
            "01713",
            "01714",
            "01718",
            "01719",
            "01721",
            "01722",
            "01723",
            "01724",
            "01727",
            "01728",
            "01731",
            "01732",
            "01733",
            "01734",
            "01743",
            "01744",
            "01747",
            "01751",
            "01752",
            "01753",
            "01754",
            "01762",
            "01767",
            "01768",
            "01769",
            "01771",
            "01777",
            "01778",
            "01779",
            "01782",
            "01783",
            "01784",
            "01786",
            "01787",
            "01788",
            "01789",
            "01791",
            "01792",
            "01793",
            "01801",
            "01802",
            "01803",
            "01804",
            "01805",
            "01806",
            "01807",
            "01808",
            "01809",
            "01812",
            "01984",
            "02000",
            "02001",
            "02002",
            "02003",
            "02004",
            "02005",
            "02006",
            "02007",
            "02009",
            "02010",
            "03000",
            "04000",
            "1001",
            "1703",
        };
    }
}
