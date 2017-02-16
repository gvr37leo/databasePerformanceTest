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

namespace couchDBCsharp
{
    class Program
    {   
        static void Main(string[] args) {
            var sw = Stopwatch.StartNew();
            Task.Run(async () => {
                var client = new MyCouchClient("http://localhost:5984/", "test");

                await client.Entities.PostAsync(new { name = "paul" });
            }).Wait();

            sw.Stop();
            Console.WriteLine($"elapsed time {sw.Elapsed}");
        }
    }
}
