using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogEenzijdigTarief : Tarief {
        

        public ZorgTogEenzijdigTarief(SqlDataReader reader2) {
            Uzovi = (short)reader2[nameof(Uzovi)];
        }

        public virtual short Uzovi { get; set; }

        public override short discriminator => 5;
    }
}