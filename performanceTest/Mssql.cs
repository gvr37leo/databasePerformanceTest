using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using System.Threading.Tasks;
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
            sqlConnection = new SqlConnection("Data Source=stan.topicus.local;Initial Catalog=ZBO_PAUL;Persist Security Info=True;User ID=sa;Password=Gehe1m");
            sqlConnection.Open();
            
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

        public async Task ForceZboZorgvoorwaarden() {
            await ForceZboZorgvoorwaarden(new List<string> { "01600", "01636", "01640" });
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

        public async Task ForceZboZorgvoorwaarden(List<string> dekkingsCodes) {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand($@"
                SELECT this_.Id                                            as Id248_3_,
                   this_.Omschrijving                                  as Omschrij2_248_3_,
                   this_.HandmatigeVerwerking                          as Handmati3_248_3_,
                   this_.Onderdeel                                     as Onderdeel248_3_,
                   this_.Conditie                                      as Conditie248_3_,
                   this_.MachtigingVereist                             as Machtigi6_248_3_,
                   this_.Percentage                                    as Percentage248_3_,
                   this_.VanTarief                                     as VanTarief248_3_,
                   zorgvoorwa2_.Id                                     as Id242_0_,
                   zorgvoorwa2_.GeldigVanafLeeftijd                    as GeldigVa2_242_0_,
                   zorgvoorwa2_.GeldigTotLeeftijd                      as GeldigTo3_242_0_,
                   zorgvoorwa2_.GeldigVanafMaandNaVerjaardag           as GeldigVa4_242_0_,
                   zorgvoorwa2_.GeldigTotMaandNaVerjaarag              as GeldigTo5_242_0_,
                   zorgvoorwa2_.GeldigVanafKalenderjaarVanafVerjaardag as GeldigVa6_242_0_,
                   zorgvoorwa2_.GeldigTotKalenderjaarNaVerjaardag      as GeldigTo7_242_0_,
                   zorgvoorwa2_.ZorgVerlenersContractSoort             as ZorgVerl8_242_0_,
                   zorgvoorwa2_.Geslacht                               as Geslacht242_0_,
                   zorgvoorwa2_.Contractnummer                         as Contrac10_242_0_,
                   zorgvoorwa2_.IsRestitutieclausule                   as IsResti11_242_0_,
                   zorgvoorwa2_.IsVrijwilligEigenRisicoAfgekocht       as IsVrijw12_242_0_,
                   zorgvoorwa2_.VerplichtEigenRisicoNiveau             as Verplic13_242_0_,
                   zorgvoorwa2_.ChronischeFysiotherapie                as Chronis14_242_0_,
                   zorgvoorwa2_.BijzondereTandheelkunde                as Bijzond15_242_0_,
                   zorgvoorwa2_.ChronischeMedicatie                    as Chronis16_242_0_,
                   zorgvoorwa2_.Buitenland                             as Buitenland242_0_,
                   zorgvoorwa2_.IndicatieSoortPrestatierecord          as Indicat18_242_0_,
                   zorgvoorwa2_.SoortKostenHulpmiddel                  as SoortKo19_242_0_,
                   zorgvoorwa2_.Zorgverlenerssoort                     as Zorgver20_242_0_,
                   zorgvoorwa2_.SoortVerwijzer                         as SoortVe21_242_0_,
                   zorgvoorwa3_.Id                                     as Id252_1_,
                   zorgvoorwa3_.VanafAantalPrestaties                  as VanafAan2_252_1_,
                   zorgvoorwa3_.VanafLeeftijd                          as VanafLee3_252_1_,
                   zorgvoorwa3_.TotLeeftijd                            as TotLeeft4_252_1_,
                   zorgvoorwa3_.NietGecontracteerdeZorgverlener        as NietGeco5_252_1_,
                   zorgvoorwa3_.HeeftUitzonderingFysiotherapie         as HeeftUit6_252_1_,
                   specificat4_.VoorwaardeDetail                       as Voorwaa17_5_,
                   specificat4_.Id                                     as Id5_,
                   specificat4_.Id                                     as Id247_2_,
                   specificat4_.MaxAantal                              as MaxAantal247_2_,
                   specificat4_.MaxBedrag                              as MaxBedrag247_2_,
                   specificat4_.VergoedingsPercentage                  as Vergoedi4_247_2_,
                   specificat4_.PerMaanden                             as PerMaanden247_2_,
                   specificat4_.PerKalenderjaren                       as PerKalen6_247_2_,
                   specificat4_.Dekkingslooptijd                       as Dekkings7_247_2_,
                   specificat4_.PerDagen                               as PerDagen247_2_,
                   specificat4_.PerEenheid                             as PerEenheid247_2_,
                   specificat4_.PerDiagnose                            as PerDiag10_247_2_,
                   specificat4_.EigenBijdrage                          as EigenBi11_247_2_,
                   specificat4_.EigenBijdragePercentage                as EigenBi12_247_2_,
                   specificat4_.PerKwartaal                            as PerKwar13_247_2_,
                   specificat4_.VergoedingsPercentageBovenMaximum      as Vergoed14_247_2_,
                   specificat4_.MaxAantalGrens2                        as MaxAant15_247_2_,
                   specificat4_.MaxBedragGrens2                        as MaxBedr16_247_2_,
                   specificat4_.VoorwaardeDetail                       as Voorwaa17_247_2_
            FROM   ZorgvoorwaardeDetail this_
                   left outer join ZorgvoorwaardeConditie zorgvoorwa2_
                     on this_.Conditie = zorgvoorwa2_.Id
                   left outer join ZorgvoorwaardeMachtigingVereist zorgvoorwa3_
                     on this_.MachtigingVereist = zorgvoorwa3_.Id
                   left outer join ZorgvoorwaardeVergoedingspecificatie specificat4_
                     on this_.Id = specificat4_.VoorwaardeDetail
            WHERE  this_.Id in (/* criteria query */ SELECT zorgvoorwa5_.Id as y0_
                                FROM   DekkingZorgCommercieelproductX this_0_
                                       inner join ZorgvoorwaardeCommercieelproduct zorgvoorwa1_
                                         on this_0_.ZorgvoorwaardeCommercieelProductId = zorgvoorwa1_.Id
                                       inner join ZorgvoorwaardeProduct zorgvoorwa2_
                                         on zorgvoorwa1_.Product = zorgvoorwa2_.Id
                                       inner join ZorgvoorwaardeProductInstantie zorgvoorwa3_
                                         on zorgvoorwa2_.Id = zorgvoorwa3_.Product
                                       inner join ZorgvoorwaardeProductInstantieZorgvoorwaardeOnderdeelX onderdelen10_
                                         on zorgvoorwa3_.Id = onderdelen10_.ZorgvoorwaardeProductInstantie
                                       inner join ZorgvoorwaardeOnderdeel zorgvoorwa4_
                                         on onderdelen10_.ZorgvoorwaardeOnderdeel = zorgvoorwa4_.Id
                                       inner join ZorgvoorwaardeDetail zorgvoorwa5_
                                         on zorgvoorwa4_.Id = zorgvoorwa5_.Onderdeel
                                WHERE  this_0_.Dekkingscode in ({String.Join(",", dekkingsCodes)}));
", sqlConnection1);
                try {
                    await sqlCommand.ExecuteNonQueryAsync();
                } catch (Exception e) {
                    Console.WriteLine("collission");
                }
            }
            
        }
    }
}
