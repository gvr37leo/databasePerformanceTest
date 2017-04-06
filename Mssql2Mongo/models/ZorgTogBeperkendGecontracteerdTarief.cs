using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mssql2Mongo.models {
    class ZorgTogBeperkendGecontracteerdTarief:Tarief {



        public ZorgTogBeperkendGecontracteerdTarief(SqlDataReader reader2) {
            Uzovi = reader2[nameof(Uzovi)] as short?;
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
        }

        public override short discriminator => 20;

        public virtual short? Uzovi { get; set; }

        public virtual int? ZorgverlenerCode { get; set; }

        public virtual long? Contractnummer { get; set; }

    }
}
