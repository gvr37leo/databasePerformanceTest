﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Neo4j.Driver.V1;

namespace neo4jCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "$RF5tg^YH"));
            var session = driver.Session();

            session.Run("CREATE (a:Person {name: {name}, title: {title}})",
                new Dictionary<string, object> { { "name", "Arthur" }, { "title", "King" } });

            var result = session.Run("MATCH (a:Person) WHERE a.name = {name} " +
                                     "RETURN a.name AS name, a.title AS title",
                                     new Dictionary<string, object> { { "name", "Arthur" } });

            foreach (var record in result)
            {
                Console.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.ReadKey();
        }
    }
}
