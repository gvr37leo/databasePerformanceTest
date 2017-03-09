using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using NHibernate.Criterion;

namespace mssql {
    class Program {
        

        static void Main(string[] args) {
            Configuration config = new Configuration();
            
            config.Configure();
            

            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(StudentMap).Assembly.GetTypes());
            mapper.AddMappings(typeof(ZorgIfmTariefMap).Assembly.GetTypes());
            mapper.CompileMappingForEachExplicitlyAddedEntity().WriteAllXmlMapping();
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            var xml = mapping.AsString();


            config.AddAssembly(typeof(ZorgIfmTarief).Assembly);
            ISessionFactory sf = config.BuildSessionFactory();
            ISession session = sf.OpenSession();

            var list = session.QueryOver<Student>()
                .Where(student => student.ID > 1)
                .Take(10)
                .List<Student>();
            


            foreach (var tar in list) {
                Console.WriteLine(tar.FirstMidName);
            }
        }
    }
}