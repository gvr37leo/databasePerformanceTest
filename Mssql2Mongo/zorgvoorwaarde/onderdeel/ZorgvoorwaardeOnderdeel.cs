using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeOnderdeel {
        public long Id { get; set; }

        public short Class { get; set; }

        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        public string Document { get; set; }

        public string Onderwerp { get; set; }

        public string Verwijzing { get; set; }

        public long? Jaar { get; set; }

        public string Clausuledocument { get; set; }

        public string ClausuleVerwijzing { get; set; }

        public List<ZorgvoorwaardeDetail> details = new List<ZorgvoorwaardeDetail>();

    }
}
