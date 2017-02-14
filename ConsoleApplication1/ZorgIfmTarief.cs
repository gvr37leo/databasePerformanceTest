using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mssql {

    class ZorgIfmTarief {

        public virtual Guid Id { get; set; }
        public virtual float BtwPercentage { get; set; }
        public virtual int GeneriekeProductcode { get; set; }
        public virtual int Artikelnummer { get; set; }
    }
}
