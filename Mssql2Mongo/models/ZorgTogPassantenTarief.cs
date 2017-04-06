using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogPassantenTarief : Tarief {
        

        public ZorgTogPassantenTarief(SqlDataReader reader2) {
            SoortZorgverlener = reader2[nameof(SoortZorgverlener)] as byte?;

            DbcPoortspecialisme = reader2[nameof(DbcPoortspecialisme)] as short?;
            Zorgverlenercode = reader2[nameof(Zorgverlenercode)] as int?;
        }

        public virtual short? DbcPoortspecialisme {
            get;
            set;
        }

        public virtual int? Zorgverlenercode {
            get;
            set;
        }

        public virtual byte? SoortZorgverlener {
            get;
            set;
        }

        public override short discriminator => 9;
    }
}