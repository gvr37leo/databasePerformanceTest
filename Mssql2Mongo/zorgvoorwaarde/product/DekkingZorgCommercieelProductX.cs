using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using performanceTest.zorgvoorwaarde.product;

namespace Mssql2Mongo.zorgvoorwaarde.product {
    class DekkingZorgCommercieelProductX {
        public long Id { get; set; }

        public string Dekkingscode { get; set; }

        public string Clausule4 { get; set; }

        public string Clausule5 { get; set; }

        public string Uzovi { get; set; }

        public long ZorgvoorwaardeCommercieelProductId { get; set; }
    }
}
