using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogEigenBijdrageTarief : Tarief {
        

        public ZorgTogEigenBijdrageTarief(SqlDataReader reader2) {
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
        }

        public virtual long? Contractnummer {
            get;
            set;
        }

        public override short discriminator => 7;
    }
}