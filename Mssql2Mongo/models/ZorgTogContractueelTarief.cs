using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mssql2Mongo.models {
    class ZorgTogContractueelTarief : Tarief{

        public ZorgTogContractueelTarief(SqlDataReader reader2){
            Uzovi = reader2[nameof(Uzovi)] as short?;
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
            TypeZorgverlenerString = reader2[nameof(TypeZorgverlenerString)] as char?;
        }

        public virtual long? Contractnummer { get; set; }
        
        public virtual short? Uzovi { get; set; }
        
        public virtual int? ZorgverlenerCode { get; set; }
        
        public virtual char? TypeZorgverlenerString { get; set; }

        public override short discriminator => 4;
    }
}
