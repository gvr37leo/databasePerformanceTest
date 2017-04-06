using System;
using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogNietGecontracteerdTarief : Tarief {
        

        public ZorgTogNietGecontracteerdTarief(SqlDataReader reader2) {
            Uzovi = (short)reader2[nameof(Uzovi)];
            ZorgvoorwaardeProductTypeByte = reader2[nameof(ZorgvoorwaardeProductTypeByte)] as byte?;
            SoortZorgverlener = reader2[nameof(SoortZorgverlener)] as byte?;
            DekkingsCode = reader2[nameof(DekkingsCode)] as string;
        }

        public virtual short Uzovi { get; set; }

        public virtual byte? ZorgvoorwaardeProductTypeByte { get; set; }
        
        public virtual byte? SoortZorgverlener { get; set; }
        
        public virtual string DekkingsCode { get; set; }

        public override short discriminator => 6;
    }
}