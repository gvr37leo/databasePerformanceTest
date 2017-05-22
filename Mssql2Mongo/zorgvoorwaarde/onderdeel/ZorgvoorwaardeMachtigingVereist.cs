using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest.zorgvoorwaarde {
    class ZorgvoorwaardeMachtigingVereist {
        public long Id { get; set; }

        public int? VanafAantalPrestaties { get; set; }

        public int? VanafLeeftijd { get; set; }

        public int? TotLeeftijd { get; set; }

        public bool? NietGecontracteerdeZorgverlener { get; set; }

        public bool? HeeftUitzonderingFysiotherapie { get; set; }
    }
}
