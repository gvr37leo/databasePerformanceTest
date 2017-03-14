using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Data.SqlClient;
using System.Reflection;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Impl;
using NHibernate.Loader.Criteria;
using NHibernate.Persister.Entity;
using performanceTest.Models;

namespace performanceTest{
    class Mssql:IDatabase {
        
        ISessionFactory factory;

        public Mssql(){
            Configuration config = new Configuration().DataBaseIntegration(db => {
                db.ConnectionString = "Data Source=stan.topicus.local;Initial Catalog=ZBO_PAUL;Persist Security Info=True;User ID=sa;Password=Gehe1m";
                db.Dialect<MySQLDialect>();
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Driver<SqlClientDriver>();
            });

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            config.AddMapping(mapping);
            factory = config.BuildSessionFactory();

            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }

        public String GetGeneratedSql(ICriteria criteria) {
            var criteriaImpl = (CriteriaImpl)criteria;
            var sessionImpl = (SessionImpl)criteriaImpl.Session;
            var factory = (SessionFactoryImpl)sessionImpl.SessionFactory;
            var implementors = factory.GetImplementors(criteriaImpl.EntityOrClassName);
            var loader = new CriteriaLoader((IOuterJoinLoadable)factory.GetEntityPersister(implementors[0]), factory, criteriaImpl, implementors[0], sessionImpl.EnabledFilters);

            return loader.SqlString.ToString();
        }

        public string Dbname { get; set; }
        public string Tablename { get; set; }
        public void ClearDb(){
            
        }

        public void FillDb(int amount){
            
        }

        public void CreateDb(){
            
        }

        public void ManyJoins(){
            
        }

        public void ManySmallQuerys(){
            
        }

        public void ForceZboSpecific(){
            using (var session = factory.OpenSession()){
                VektisAanduidingPrestatiecodelijst prestatiecodelijst = new VektisAanduidingPrestatiecodelijst(0);
                prestatiecodelijst.Code = 0;
                string dbcDeclaratiecode = "";

                var query = session.QueryOver<ZorgTogTariefWereld>()
                    .Where(t => t.Prestatiecodelijst == prestatiecodelijst.Code)
                    .And(t => t.DbcDeclaratiecode == dbcDeclaratiecode);

                var generatedSQL = GetGeneratedSql(query.UnderlyingCriteria);
                


                var list = query
                    .Fetch(t => t.Tarieven).Eager
                    .FutureValue().Value;
            }
        }

        public void IndexedSearch(){
            
        }

        public void NoIndexSearch(){
            
        }

        public void EmbeddedVsJoin(){
            
        }

        public void Create(){
            using (var session = factory.OpenSession()) 
            using (var transaction = session.BeginTransaction()) 
            {
                session.SaveOrUpdate(new Person());
                transaction.Commit();
            }
        }

        public void Read(){
            using(var session = factory.OpenSession()) {
                var list = session.QueryOver<Person>()
                        .List<Person>();
            }
        }

        public void Update(){
            using (var session = factory.OpenSession())
            using (var transaction = session.BeginTransaction()) {
                session.Update(new Person());
                transaction.Commit();
            }
        }

        public void Delete(){
            
        }
    }
}
