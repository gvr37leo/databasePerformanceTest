using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeProduct {
        public long Id;
        public List<ZorgvoorwaardeCommercieelProduct> CommercieelProduct = new List<ZorgvoorwaardeCommercieelProduct>();
        public List<ZorgvoorwaardeProductInstantie> ProductInstanties = new List<ZorgvoorwaardeProductInstantie>();
    }
}
