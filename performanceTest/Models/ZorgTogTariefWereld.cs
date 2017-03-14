using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;

namespace performanceTest.Models {
    //[Subclass(NameType = typeof(ZorgTogTariefWereld), ExtendsType = typeof(ZorgPrestatieTariefWereld), DiscriminatorValueObject = DISCRIMINATOR)]
    public class ZorgTogTariefWereld : ZorgPrestatieTariefWereld {
        public new const short DISCRIMINATOR = 1;
        public const string STR_PRESTATIECODELIJST = "Prestatiecodelijst";
        public const string STR_DBCDECLARATIECODE = "DbcDeclaratiecode";

        //[Bag(0, Table = ZorgTogTarief.TABLENAME)]
        //[Key(1, Column = ZorgTogTarief.STR_TOGTARIEFWERELD)]
        //[OneToMany(2, ClassType = typeof(ZorgTogTarief))]
        public override IEnumerable<ZorgTarief> Tarieven {
            get { return base.Tarieven; }
            protected set { base.Tarieven = value; }
        }

        //[Property]
        public virtual short? Prestatiecodelijst { get; set; }

        //[Property(Length = 6)]
        public virtual string DbcDeclaratiecode { get; set; }
    }

    public class ZorgTogTariefWereldMap : SubclassMapping<ZorgTogTariefWereld> {
        public ZorgTogTariefWereldMap() {
            Bag(zttw => zttw.Tarieven, c =>{
                c.Table("ZorgTogTarief");
                c.Key(t => t.Column(ZorgTogTarief.STR_TOGTARIEFWERELD));
            }, r => r.OneToMany(mapper => mapper.Class(typeof(ZorgTogTarief))));
            DiscriminatorValue(1);
            Property(zt => zt.Prestatiecodelijst);
            Property(zt => zt.DbcDeclaratiecode, m => m.Length(6));
        }
    }
}