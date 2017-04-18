using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using Dapper;
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
        SqlConnection sqlConnection;
        string connectionString = "Data Source = stan.topicus.local; Initial Catalog = ZBO_PAUL; Persist Security Info = True; User ID = sa; Password = Gehe1m";

        public Mssql(){
            //sqlConnection = new SqlConnection("Data Source=stan.topicus.local;Initial Catalog=ZBO_PAUL;Persist Security Info=True;User ID=sa;Password=Gehe1m");
            ////sqlConnection.Open();
            //Configuration config = new Configuration().DataBaseIntegration(db => {
            //    db.ConnectionString = connectionString;
            //    db.Dialect<MySQLDialect>();
            //    db.ConnectionProvider<DriverConnectionProvider>();
            //    db.Driver<SqlClientDriver>();
            //    //db.LogSqlInConsole = true;
            //});



            //var mapper = new ModelMapper();
            //mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            //HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            //config.AddMapping(mapping);
            //factory = config.BuildSessionFactory();

            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }

        public string GetGeneratedSql(ICriteria criteria) {
            var criteriaImpl = criteria as CriteriaImpl;
            var sessionImpl = criteriaImpl.Session;
            var factory = sessionImpl.Factory;
            var implementors = factory.GetImplementors(criteriaImpl.EntityOrClassName);
            var loader = new CriteriaLoader(factory.GetEntityPersister(implementors[0]) as IOuterJoinLoadable, factory, criteriaImpl, implementors[0], sessionImpl.EnabledFilters);
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
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                var tarieven = sqlConnection1.Query< ZorgTarief, ZorgTogTariefWereld, ZorgTarief>(@"select*
                from ZorgTogTarief z
                         inner join ZorgPrestatieTariefWereld zw on zw.id = z.TogTariefWereld
                         where zw.class = 1 
                         and zw.DbcDeclaratiecode = '190600'
                         and zw.Prestatiecodelijst = 41", 
                         (tarief, tariefwereld) =>{
                             tarief.Wereld = tariefwereld;

                             return tarief;
                         }).ToList();
                

                //SqlCommand cmd = new SqlCommand {
                //    CommandText = $@"
                //select*
                //from ZorgPrestatieTariefWereld zw
                //         inner join ZorgTogTarief z on zw.id = z.TogTariefWereld
                //         where zw.class = 1 
                //         and zw.DbcDeclaratiecode = '190600'
                //         and zw.Prestatiecodelijst = 41
                //        ",
                //    CommandType = CommandType.Text,
                //    Connection = sqlConnection1
                //};
                //var reader = cmd.ExecuteReader();
                ////var list
                //while (reader.Read()) {
                //    //var x = reader[null];
                //}
            }

            //    using (var session = factory.OpenSession()) {
            //        var query = session.QueryOver<ZorgTogTariefWereld>()
            //            .Where(t => t.Prestatiecodelijst == 41)
            //            .And(t => t.DbcDeclaratiecode == "190600");
            //        var list = query
            //            .Fetch(t => t.Tarieven).Eager
            //            .FutureValue().Value;

            //    }
        }

        public void IndexedSearch(){
            using (var session = factory.OpenSession()) {
                var query = session.QueryOver<Person>()
                        .Where(p => p.ID == 2713998782023081984);
                var res = query.List();
                

            }
        }

        public void NoIndexSearch(){
            using (var session = factory.OpenSession()) {
                var query = session.QueryOver<Person>()
                        .Where(p => p.LastName == "630og");
                var res = query.List();


            }
        }

        public void EmbeddedVsJoin(){
            
        }

        public void Create(){
            var person = new Person();
            
            SqlCommand sqlCommand = new SqlCommand($@"
                insert into person (LastName,FirstMidName,ID)
                values('{person.LastName}','{person.FirstMidName}',{person.ID})
            ", sqlConnection);
            try {
                sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("collission");
            }
            
            //using (var session = factory.OpenSession()) 
            //using (var transaction = session.BeginTransaction()) 
            //{
            //    session.SaveOrUpdate(new Person());
            //    transaction.Commit();
            //}
        }

        public void Read(){
            using(var session = factory.OpenSession()) {
                var list = session.QueryOver<Person>()
                        .Where(p => p.LastName == "sdfsa");
                var query = list.UnderlyingCriteria;
                var generatedSQL = GetGeneratedSql(query);

                var result = query
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
