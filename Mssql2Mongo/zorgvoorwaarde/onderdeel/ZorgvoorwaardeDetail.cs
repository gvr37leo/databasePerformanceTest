using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeDetail {
        public long Id;
        public long Onderdeel;
        public ZorgvoorwaardeConditie Conditie;
        public ZorgvoorwaardeMachtigingVereist MachtigingVereist;
        public ZorgvoorwaardeVergoedingSpecificatie VergoedingSpecificatie;
    }
}
