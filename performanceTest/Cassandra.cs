using System.Runtime.InteropServices;
using Cassandra;

namespace performanceTest {
    class Cassandra {

        Cassandra(){
            var cluster = Cluster.Builder().AddContactPoint("").Build();
            var session = cluster.Connect("keyspace");
            var rs = session.Execute("query");

        }
    }
}
