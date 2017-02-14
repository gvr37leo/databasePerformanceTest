using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using System.IO;
using NHibernate.Tool.hbm2ddl;

namespace mssql {
    class Program {
        

        static void Main(string[] args) {
            Configuration config = new Configuration();
            config.Configure();

            config.AddAssembly(typeof(Student).Assembly);
            ISessionFactory sf = config.BuildSessionFactory();
            ISession session = sf.OpenSession();

            var list = session.QueryOver<Student>().Select(s => s.FirstMidName).List<string>();

            foreach (var tar in list) {
                Console.WriteLine(tar);
            }

            Console.Read();
        }
    }
}