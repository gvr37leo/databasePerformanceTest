using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace mssql {

    class ZorgIfmTarief {

        public virtual int Id { get; set; }
        public virtual int Artikelnummer { get; set; }
    }

    class ZorgIfmTariefMap : ClassMapping<ZorgIfmTarief> {
        public ZorgIfmTariefMap() {
            Id(p => p.Id, map => map.Generator(Generators.Assigned));
            Property(p => p.Artikelnummer);
        }
    }
}
