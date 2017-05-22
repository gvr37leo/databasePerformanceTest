using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeConditie {
        public long Id { get; set; }

        public int? GeldigVanafLeeftijd { get; set; }

        public int? GeldigTotLeeftijd { get; set; }

        public int? GeldigVanafMaandNaVerjaardag { get; set; }

        public int? GeldigTotMaandNaVerjaarag { get; set; }

        public int? GeldigVanafKalenderjaarVanafVerjaardag { get; set; }

        public int? GeldigTotKalenderjaarNaVerjaardag { get; set; }

        public int? ZorgVerlenersContractSoort { get; set; }

        public int? Geslacht { get; set; }

        public long? Contractnummer { get; set; }

        public bool? IsRestitutieclausule { get; set; }

        public bool IsVrijwilligEigenRisicoAfgekocht { get; set; }

        public byte? VerplichtEigenRisicoNiveau { get; set; }

        public short ChronischeFysiotherapie { get; set; }

        public short BijzondereTandheelkunde { get; set; }

        public byte? Buitenland { get; set; }

        public byte? IndicatieSoortPrestatierecord { get; set; }

        public byte? SoortKostenHulpmiddel { get; set; }

        public short? ChronischeMedicatie { get; set; }

        public string Zorgverlenerssoort { get; set; }

        public string SoortVerwijzer { get; set; }
    }
}
