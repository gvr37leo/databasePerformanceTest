using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mssql2Mongo.zorgvoorwaarde.product;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeCommercieelProduct {
        public long Id { get; set; }

        public List<DekkingZorgCommercieelProductX> Dekkingen { get; set; } 
            = new List<DekkingZorgCommercieelProductX>();

        public string Naam { get; set; }

        public long? Product { get; set; }

        public bool Actief { get; set; }
    }
}
