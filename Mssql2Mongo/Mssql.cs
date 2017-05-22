using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Mssql2Mongo.models;
using Mssql2Mongo.zorgvoorwaarde.product;
using Newtonsoft.Json;
using Neo4j.Driver.V1;
using performanceTest.zorgvoorwaarde;
using performanceTest.zorgvoorwaarde.product;

namespace Mssql2Mongo {
    class Mssql {
        string connectionString = "Data Source = stan.topicus.local; Initial Catalog = ZBO_PAUL; Persist Security Info = True; User ID = sa; Password = Gehe1m";
        Mongo mongo;
        MongoClient client;
        IMongoDatabase database;

        public Mssql(){
            mongo = new Mongo();
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("zorgvoorwaarden");
        }

        public void readWrite() {//order is important
//            Producten();
//
//            CommercieleProducten();
//            DekkingKoppelingen();
//
//            Instanties();
//            OnderdelenReferenties();
//
//            Onderdelen();
//            Details();
//            Condities();
//            Machtigingen();
            VergoedingSpecificaties();
        }

        private void Onderdelen() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[class]
                                  ,[Naam]
                                  ,[Omschrijving]
                                  ,[Document]
                                  ,[Onderwerp]
                                  ,[Verwijzing]
                                  ,[Jaar]
                                  ,[Clausuledocument]
                                  ,[ClausuleVerwijzing]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeOnderdeel]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeOnderdeel {
                        Id = ConvertFromDBVal<long>(reader[0]),
                        Class = ConvertFromDBVal<short>(reader[1]),
                        Naam = ConvertFromDBVal<string>(reader[2]),
                        Omschrijving = ConvertFromDBVal<string>(reader[3]),
                        Document = ConvertFromDBVal<string>(reader[4]),
                        Onderwerp = ConvertFromDBVal<string>(reader[5]),
                        Verwijzing = ConvertFromDBVal<string>(reader[6]),
                        Jaar = ConvertFromDBVal<long>(reader[7]),
                        Clausuledocument = ConvertFromDBVal<string>(reader[8]),
                        ClausuleVerwijzing = ConvertFromDBVal<string>(reader[9]),
                    };
                    database.GetCollection<BsonDocument>("onderdelen")
                        .InsertOne(product.ToBsonDocument());

                }
            }
        }

        private void Details() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[Omschrijving]
                                  ,[HandmatigeVerwerking]
                                  ,[Onderdeel]
                                  ,[Conditie]
                                  ,[MachtigingVereist]
                                  ,[Percentage]
                                  ,[VanTarief]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeDetail]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeDetail(){
                        Id = (long)reader[0],
                        Omschrijving = ConvertFromDBVal<string>(reader[1]),
                        HandmatigeVerwerking = ConvertFromDBVal<bool>(reader[2]),
                        Onderdeel = ConvertFromDBVal<long>(reader[3]),
                        Conditie = ConvertFromDBVal<long>(reader[4]),
                        MachtigingVereist = ConvertFromDBVal<long>(reader[5]),
                        Percentage = ConvertFromDBVal<int>(reader[6]),
                        VanTarief = ConvertFromDBVal<int>(reader[7]),
                    };
                    database.GetCollection<BsonDocument>("onderdelen")
                        .UpdateOne(new BsonDocument { { "_id", product.Onderdeel } },
                            new BsonDocument { { "$push", new BsonDocument { { "details", product.ToBsonDocument() } } } });

                }
            }
        }

        private void Condities() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[GeldigVanafLeeftijd]
                                  ,[GeldigTotLeeftijd]
                                  ,[GeldigVanafMaandNaVerjaardag]
                                  ,[GeldigTotMaandNaVerjaarag]
                                  ,[GeldigVanafKalenderjaarVanafVerjaardag]
                                  ,[GeldigTotKalenderjaarNaVerjaardag]
                                  ,[ZorgVerlenersContractSoort]
                                  ,[Geslacht]
                                  ,[Contractnummer]
                                  ,[IsRestitutieclausule]
                                  ,[IsVrijwilligEigenRisicoAfgekocht]
                                  ,[VerplichtEigenRisicoNiveau]
                                  ,[ChronischeFysiotherapie]
                                  ,[BijzondereTandheelkunde]
                                  ,[Buitenland]
                                  ,[IndicatieSoortPrestatierecord]
                                  ,[SoortKostenHulpmiddel]
                                  ,[ChronischeMedicatie]
                                  ,[Zorgverlenerssoort]
                                  ,[SoortVerwijzer]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeConditie]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeConditie() {
                        Id = (long)reader[0],
                        GeldigVanafLeeftijd = ConvertFromDBVal<int>(reader[1]),
                        GeldigTotLeeftijd = ConvertFromDBVal<int>(reader[2]),
                        GeldigVanafMaandNaVerjaardag = ConvertFromDBVal<int>(reader[3]),
                        GeldigTotMaandNaVerjaarag = ConvertFromDBVal<int>(reader[4]),
                        GeldigVanafKalenderjaarVanafVerjaardag = ConvertFromDBVal<int>(reader[5]),
                        GeldigTotKalenderjaarNaVerjaardag = ConvertFromDBVal<int>(reader[6]),
                        ZorgVerlenersContractSoort = ConvertFromDBVal<int>(reader[7]),
                        Geslacht = ConvertFromDBVal<int>(reader[8]),
                        Contractnummer = ConvertFromDBVal<long>(reader[9]),
                        IsRestitutieclausule = ConvertFromDBVal<bool>(reader[10]),
                        IsVrijwilligEigenRisicoAfgekocht = ConvertFromDBVal<bool>(reader[11]),
                        VerplichtEigenRisicoNiveau = ConvertFromDBVal<byte>(reader[12]),
                        ChronischeFysiotherapie = ConvertFromDBVal<short>(reader[13]),
                        BijzondereTandheelkunde = ConvertFromDBVal<short>(reader[14]),
                        Buitenland = ConvertFromDBVal<byte>(reader[15]),
                        IndicatieSoortPrestatierecord = ConvertFromDBVal<byte>(reader[16]),
                        SoortKostenHulpmiddel = ConvertFromDBVal<byte>(reader[17]),
                        ChronischeMedicatie = ConvertFromDBVal<short>(reader[18]),
                        Zorgverlenerssoort = ConvertFromDBVal<string>(reader[19]),
                        SoortVerwijzer = ConvertFromDBVal<string>(reader[20]),
                    };
                    database.GetCollection<BsonDocument>("onderdelen")
                        .UpdateOne(new BsonDocument { { "details.Conditie", product.Id } },
                            new BsonDocument { { "$set", new BsonDocument { { "details.$.ConditieObject", product.ToBsonDocument() } } } });


                }
            }
        }

        private void Machtigingen() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[VanafAantalPrestaties]
                                  ,[VanafLeeftijd]
                                  ,[TotLeeftijd]
                                  ,[NietGecontracteerdeZorgverlener]
                                  ,[HeeftUitzonderingFysiotherapie]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeMachtigingVereist]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeMachtigingVereist() {
                        Id = (long)reader[0],
                        VanafAantalPrestaties = ConvertFromDBVal<int>(reader[1]),
                        VanafLeeftijd = ConvertFromDBVal<int>(reader[2]),
                        TotLeeftijd = ConvertFromDBVal<int>(reader[3]),
                        NietGecontracteerdeZorgverlener = ConvertFromDBVal<bool>(reader[4]),
                        HeeftUitzonderingFysiotherapie = ConvertFromDBVal<bool>(reader[5]),
                    };
                    database.GetCollection<BsonDocument>("onderdelen")
                        .UpdateOne(new BsonDocument { { "details.MachtigingVereist", product.Id } },
                            new BsonDocument { { "$set", new BsonDocument { { "details.$.MachtigingVereistObject", product.ToBsonDocument() } } } });


                }
            }
        }

        private void VergoedingSpecificaties() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[MaxAantal]
                                  ,[MaxBedrag]
                                  ,[VergoedingsPercentage]
                                  ,[PerMaanden]
                                  ,[PerKalenderjaren]
                                  ,[Dekkingslooptijd]
                                  ,[PerDagen]
                                  ,[PerEenheid]
                                  ,[EigenBijdrage]
                                  ,[PerKwartaal]
                                  ,[VergoedingsPercentageBovenMaximum]
                                  ,[VoorwaardeDetail]
                                  ,[MaxAantalGrens2]
                                  ,[MaxBedragGrens2]
                                  ,[EigenBijdragePercentage]
                                  ,[PerDiagnose]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeVergoedingSpecificatie]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeVergoedingSpecificatie();
                    product.Id = (long) reader[0];
                    product.MaxAantal = ConvertFromDBVal<int>(reader[1]);
                    product.MaxBedrag = ConvertFromDBVal<int>(reader[2]);
                    product.VergoedingsPercentage = ConvertFromDBVal<int>(reader[3]);
                    product.PerMaanden = ConvertFromDBVal<int>(reader[4]);
                    product.PerKalenderjaren = ConvertFromDBVal<int>(reader[5]);
                    product.Dekkingslooptijd = ConvertFromDBVal<bool>(reader[6]);
                    product.PerDagen = ConvertFromDBVal<int>(reader[7]);
                    product.PerEenheid = ConvertFromDBVal<bool>(reader[8]);
                    product.EigenBijdrage = ConvertFromDBVal<int>(reader[9]);
                    product.PerKwartaal = ConvertFromDBVal<bool>(reader[10]);
                    product.VergoedingsPercentageBovenMaximum = ConvertFromDBVal<int>(reader[11]);
                    product.VoorwaardeDetail = ConvertFromDBVal<long>(reader[12]);
                    product.MaxAantalGrens2 = ConvertFromDBVal<int>(reader[13]);
                    product.MaxBedragGrens2 = ConvertFromDBVal<int>(reader[14]);
                    product.EigenBijdrage = ConvertFromDBVal<int>(reader[15]);
                    product.PerDiagnose = ConvertFromDBVal<bool>(reader[16]);
                    
                    database.GetCollection<BsonDocument>("onderdelen")
                        .UpdateOne(new BsonDocument { { "details._id", product.VoorwaardeDetail } },
                            new BsonDocument { { "$set", new BsonDocument { { "details.$.VergoedingSpecificatie", product.ToBsonDocument() } } } });


                }
            }
        }

        private void Producten() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                              ,[class]
                              ,[Naam]
                              ,[Omschrijving]
                              ,[Productsoort]
                              ,[Polissoort]
                              ,[StandaardProduct]
                              ,[IsRestitutieclausule]
                              ,[ZorgvoorwaardeProductTypeByte]
                          FROM [ZorgvoorwaardeProduct]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeProduct {
                        Id = (long)reader[0],
                        Class = (short)reader[1],
                        Naam = Convert.ToString(reader[2]),
                        Omschrijving = Convert.ToString(reader[3]),
                        Productsoort = ConvertFromDBVal<int>(reader[4]),
                        Polissoort = ConvertFromDBVal<int>(reader[5]),
                        StandaardProduct = ConvertFromDBVal<long>(reader[6]),
                        IsRestitutieclausule = ConvertFromDBVal<bool>(reader[7]),
                        ZorgvoorwaardeProductTypeByte = ConvertFromDBVal<byte>(reader[8]),
                    };
                    database.GetCollection<BsonDocument>("producten")
                        .InsertOne(product.ToBsonDocument());

                }
            }
        }

        private void Instanties() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[Product]
                                  ,[Jaar]
                              FROM [ZorgvoorwaardeProductInstantie]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeProductInstantie() {
                        Id = ConvertFromDBVal<long>(reader[0]),
                        Product = ConvertFromDBVal<long>(reader[1]),
                        Jaar = ConvertFromDBVal<long>(reader[2]),
                    };

                    database.GetCollection<BsonDocument>("producten")
                        .UpdateOne(new BsonDocument { { "_id", product.Product } },
                            new BsonDocument { { "$push", new BsonDocument { { "ProductInstanties", product.ToBsonDocument() } } } });

                }
            }
        }

        private void OnderdelenReferenties() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [ZorgvoorwaardeProductInstantie]
                                  ,[ZorgvoorwaardeOnderdeel]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeProductInstantieZorgvoorwaardeOnderdeelX]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);


                    database.GetCollection<BsonDocument>("producten")
                        .UpdateOne(new BsonDocument { { "ProductInstanties._id", (long)reader[0] } },
                            new BsonDocument { { "$push", new BsonDocument { { "ProductInstanties.$.Onderdelen", (long)reader[1] } } } });

                }
            }
        }

        private void CommercieleProducten() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[Naam]
                                  ,[Product]
                                  ,[Actief]
                              FROM [ZBO_PAUL].[dbo].[ZorgvoorwaardeCommercieelProduct]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new ZorgvoorwaardeCommercieelProduct {
                        Id = ConvertFromDBVal<long>(reader[0]),
                        Naam = ConvertFromDBVal<string>(reader[1]),
                        Product = ConvertFromDBVal<long>(reader[2]),
                        Actief = ConvertFromDBVal<bool>(reader[3]),
                    };

                    database.GetCollection<BsonDocument>("producten")
                        .UpdateOne(new BsonDocument { { "_id", product.Product } },
                            new BsonDocument { { "$push", new BsonDocument { { "CommercieleProducten", product.ToBsonDocument() } } } });
                }
            }
        }

        private void DekkingKoppelingen() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT [Id]
                                  ,[Dekkingscode]
                                  ,[Clausule4]
                                  ,[Clausule5]
                                  ,[Uzovi]
                                  ,[ZorgvoorwaardeCommercieelProductId]
                              FROM [ZBO_PAUL].[dbo].[DekkingZorgCommercieelProductX]
                        ",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                var reader = cmd.ExecuteReader();
                for (int i = 0; reader.Read(); i++) {
                    if (i % 1000 == 0) Console.WriteLine(i);

                    var product = new DekkingZorgCommercieelProductX {
                        Id = ConvertFromDBVal<long>(reader[0]),
                        Dekkingscode = ConvertFromDBVal<string>(reader[1]),
                        Clausule4 = ConvertFromDBVal<string>(reader[2]),
                        Clausule5 = ConvertFromDBVal<string>(reader[3]),
                        Uzovi = ConvertFromDBVal<string>(reader[4]),
                        ZorgvoorwaardeCommercieelProductId = ConvertFromDBVal<long>(reader[5]),
                    };

                    database.GetCollection<BsonDocument>("producten")
                        .UpdateOne(new BsonDocument { { "CommercieleProducten._id", product.ZorgvoorwaardeCommercieelProductId } },
                            new BsonDocument { { "$push", new BsonDocument { { "CommercieleProducten.$.Dekkingen", product.ToBsonDocument() } } } });

                }
            }
        }

        public static T ConvertFromDBVal<T>(object obj) {
            if (obj == null || obj == DBNull.Value) {
                return default(T); // returns the default value for the type
            } else {
                return (T)obj;
            }
        }
    }
}
