using System;
using System.Collections.Generic;
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

            Task.Run(async () => {
                var client = new MyCouchClient("http://localhost:5984/", "test");

                Console.WriteLine("start req");
                await client.Entities.PostAsync(new { name = "paul" });
            }).Wait();
            Console.WriteLine("done");
        }
    }
}
