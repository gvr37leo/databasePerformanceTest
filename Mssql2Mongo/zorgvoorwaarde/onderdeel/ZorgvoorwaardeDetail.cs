using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeDetail {
        public long Id { get; set; }

        public string Omschrijving { get; set; }

        public bool? HandmatigeVerwerking { get; set; }

        public long? Onderdeel { get; set; }

        public long? Conditie { get; set; }

        public long? MachtigingVereist { get; set; }

        public int? Percentage { get; set; }

        public int? VanTarief { get; set; }

        public ZorgvoorwaardeConditie ConditieObject;
        public ZorgvoorwaardeMachtigingVereist MachtigingVereistObject;
        public ZorgvoorwaardeVergoedingSpecificatie VergoedingSpecificatie;
    }
}
