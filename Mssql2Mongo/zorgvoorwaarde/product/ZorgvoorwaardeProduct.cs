using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde.product {
    class ZorgvoorwaardeProduct {
        public long Id { get; set; }
        public List<ZorgvoorwaardeCommercieelProduct> CommercieleProducten { get; set; }
            = new List<ZorgvoorwaardeCommercieelProduct>();
        public List<ZorgvoorwaardeProductInstantie> ProductInstanties { get; set; } 
            = new List<ZorgvoorwaardeProductInstantie>();

        public short Class {
            get;
            set;
        }

        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        public int? Productsoort { get; set; }

        public int? Polissoort { get; set; }

        public long? StandaardProduct { get; set; }

        public bool? IsRestitutieclausule { get; set; }

        public byte? ZorgvoorwaardeProductTypeByte { get; set; }
    }
}
