using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeProductInstantie {
        public long Id { get; set; }

        public long? Product { get; set; }

        public long? Jaar { get; set; }

        public List<ZorgvoorwaardeOnderdeel> Onderdelen = new List<ZorgvoorwaardeOnderdeel>();
    }
}
