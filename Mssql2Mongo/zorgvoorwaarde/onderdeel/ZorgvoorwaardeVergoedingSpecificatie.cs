using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeVergoedingSpecificatie {
        public long Id { get; set; }

        public int? MaxAantal { get; set; }

        public int? MaxBedrag { get; set; }

        public int? VergoedingsPercentage { get; set; }

        public int? PerMaanden { get; set; }

        public int? PerKalenderjaren { get; set; }

        public bool? Dekkingslooptijd { get; set; }

        public int? PerDagen { get; set; }

        public bool? PerEenheid { get; set; }

        public int? EigenBijdrage { get; set; }

        public bool? PerKwartaal { get; set; }

        public int? VergoedingsPercentageBovenMaximum { get; set; }

        public long? VoorwaardeDetail { get; set; }

        public int? MaxAantalGrens2 { get; set; }

        public int? MaxBedragGrens2 { get; set; }

        public int? EigenBijdragePercentage { get; set; }

        public bool? PerDiagnose { get; set; }
    }
}
