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

            Onderdelen();
            Details();
            Condities();
            Machtigingen();
            VergoedingSpecificaties();
        }

        private void Onderdelen() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT TOP 1000 [Id]
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
                        Id = (long)reader[0],
                        ZorgvoorwaardeProductTypeByte = ConvertFromDBVal<byte>(reader[8]),
                    };
                    database.GetCollection<BsonDocument>("producten")
                        .InsertOne(product.ToBsonDocument());

                }
            }
        }

        private void Details() {
            using (var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                            SELECT TOP 1000 [Id]
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
                    };
                    database.GetCollection<BsonDocument>("producten")
                        .InsertOne(product.ToBsonDocument());

                }
            }
        }

        private void Condities() {
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

        private void Machtigingen() {
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

        private void VergoedingSpecificaties() {
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
                            SELECT TOP 1000 [Id]
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
                        Id = (long)reader[0],
                        Product = (long)reader[1],
                        Jaar = (long)reader[2],
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
                            SELECT TOP 1000 [ZorgvoorwaardeProductInstantie]
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
                            SELECT TOP 1000 [Id]
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
                            SELECT TOP 1000 [Id]
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
