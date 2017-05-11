using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mssql2Mongo.zorgvoorwaarde.product;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeCommercieelProduct {
        public long Id;
        List<DekkingZorgCommercieelProductX> dekkingen = new List<DekkingZorgCommercieelProductX>();
    }
}
