using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using MyCouch;//https://github.com/danielwertheim/mycouch
using performanceTest.Models;


namespace couchDBCsharp
{
    class Program
    {   
        static void Main(string[] args) {
            var sw = Stopwatch.StartNew();
            Task.Run(async () => {
                var client = new MyCouchClient("http://localhost:5984/", "test");

                var json = JsonConvert.SerializeObject(new Person());

                await client.Documents.PostAsync(json);//newtonsoft.json
            }).Wait();

            sw.Stop();
            Console.WriteLine($"elapsed time {sw.Elapsed}");
        }
    }
}
