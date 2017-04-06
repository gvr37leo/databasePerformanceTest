using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogLandelijkTarief : Tarief {
        

        public ZorgTogLandelijkTarief(SqlDataReader reader2) {
            DbcPoortspecialisme = reader2[nameof(DbcPoortspecialisme)] as short?;
        }

        public virtual short? DbcPoortspecialisme {
            get;
            set;
        }

        public override short discriminator => 2;
    }
}