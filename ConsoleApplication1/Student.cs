using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mssql {
    class Student {

        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstMidName { get; set; }
    }

    class StudentMap : ClassMapping<Student> {
        public StudentMap(){
            Id(p => p.ID, map => map.Generator(Generators.Assigned));
            Property(p => p.FirstMidName);
            Property(p => p.LastName);
        }
    }
}
