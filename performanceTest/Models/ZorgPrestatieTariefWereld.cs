using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace performanceTest.Models{
    public abstract class ZorgPrestatieTariefWereld {
        private IList<ZorgTarief> tarieven = new List<ZorgTarief>();
        public const string TABLENAME = "ZorgPrestatieTariefWereld";
       

        public const string STR_ID = "Id";

        //[Id(-2, Name = STR_ID), Generator(-1, Class = "native")]
        public virtual long? Id { get; set; }

        public virtual IList<ZorgTarief> Tarieven {
            get { return tarieven; }
            set { tarieven = value; }
        }

        protected ZorgPrestatieTariefWereld(){
            
        }
    }

    public class ZorgPrestatieTariefWereldMap : ClassMapping<ZorgPrestatieTariefWereld>{
        public ZorgPrestatieTariefWereldMap(){
            Id(zptw => zptw.Id, m => m.Generator(Generators.Native));
        }
    }
}