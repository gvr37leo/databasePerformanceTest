using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeProductInstantie {
        public long Id;
        public long Product;
        public List<ZorgvoorwaardeOnderdeel> Onderdelen = new List<ZorgvoorwaardeOnderdeel>();
    }
}
