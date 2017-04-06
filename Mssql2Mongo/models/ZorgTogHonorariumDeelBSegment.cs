using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogHonorariumDeelBSegment : Tarief {
        

        public ZorgTogHonorariumDeelBSegment(SqlDataReader reader2) {
                
        }

        public override short discriminator => 14;
    }
}