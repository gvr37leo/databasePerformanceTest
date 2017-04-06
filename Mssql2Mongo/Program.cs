using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mssql2Mongo {
    class Program {
        static void Main(string[] args) {
            var mssql = new Mssql();
            mssql.readWrite();
        }
    }
}
