﻿using System.Data.SqlClient;
using Mssql2Mongo.models;

namespace Mssql2Mongo {
    internal class ZorgTogKortingsTarief : Tarief {
        
        public ZorgTogKortingsTarief(SqlDataReader reader2) {
            Uzovi = reader2[nameof(Uzovi)] as short?;
            ZorgverlenerCode = reader2[nameof(ZorgverlenerCode)] as int?;
            Contractnummer = reader2[nameof(Contractnummer)] as long?;
        }

        public virtual long? Contractnummer { get; set; }
        
        public virtual short? Uzovi { get; set; }
        
        public virtual int? ZorgverlenerCode { get; set; }

        public override short discriminator => 21;
    }
}