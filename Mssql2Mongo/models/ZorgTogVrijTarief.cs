using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogVrijTarief : Tarief {
        

        public ZorgTogVrijTarief(SqlDataReader reader2) {
            
        }

        public override short discriminator => 10;
    }
}