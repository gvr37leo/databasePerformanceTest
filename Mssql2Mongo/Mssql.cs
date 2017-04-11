﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Mssql2Mongo.models;
using Newtonsoft.Json;

namespace Mssql2Mongo {
    class Mssql {
        string connectionString = "Data Source = stan.topicus.local; Initial Catalog = ZBO_PAUL; Persist Security Info = True; User ID = sa; Password = Gehe1m";
        Mongo mongo;

        public Mssql(){
            mongo = new Mongo();
        }

        public void readWrite(){
            using(var sqlConnection1 = new SqlConnection(connectionString)) {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = $@"
                        SELECT top 10 id, DbcDeclaratiecode, Prestatiecodelijst
                        FROM ZorgPrestatieTariefWereld
                        where class = 1 --TOG",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                };
                int i = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    i++;
                    if(i % 1000 == 0) Console.WriteLine(i);

                    TariefWereld tariefWereld = new TariefWereld();
                    tariefWereld.Id = (long)reader[nameof(tariefWereld.Id)];
                    tariefWereld.DbcDeclaratiecode = (string)reader[nameof(tariefWereld.DbcDeclaratiecode)];
                    tariefWereld.Prestatiecodelijst = reader[nameof(tariefWereld.Prestatiecodelijst)] as short?;


                    using (var conn2 = new SqlConnection(connectionString)) {
                        
                        conn2.Open();
                        SqlCommand cmd2 = new SqlCommand {
                            CommandText = $@"
                                select top 10 *
                                from ZorgTogTarief z
                                where z.togtariefwereld = {tariefWereld.Id}",
                            CommandType = CommandType.Text,
                            Connection = conn2
                        };

                        var reader2 = cmd2.ExecuteReader();
                        while (reader2.Read()) {
                            Tarief tarief;
                            short discriminator = (short)reader2["class"];
                            switch (discriminator) {
                                case 2:
                                    tarief = new ZorgTogLandelijkTarief(reader2);
                                    break;
                                case 3:
                                    tarief = new ZorgTogIndividueelTarief(reader2);
                                    break;
                                case 4:
                                    tarief = new ZorgTogContractueelTarief(reader2);
                                    break;
                                case 5:
                                    tarief = new ZorgTogEenzijdigTarief(reader2);
                                    break;
                                case 6:
                                    tarief = new ZorgTogNietGecontracteerdTarief(reader2);
                                    break;
                                case 7:
                                    tarief = new ZorgTogEigenBijdrageTarief(reader2);
                                    break;
                                case 8:
                                    tarief = new ZorgTogIndividueelSluittarief(reader2);
                                    break;
                                case 9:
                                    tarief = new ZorgTogPassantenTarief(reader2);
                                    break;
                                case 10://11-12-13-18 dont exist for TOG tarieven
                                    tarief = new ZorgTogVrijTarief(reader2);
                                    break;
                                case 14:
                                    tarief = new ZorgTogHonorariumDeelBSegment(reader2);
                                    break;
                                case 15:
                                    tarief = new ZorgTogAfgeleidContractueelTarief(reader2);
                                    break;
                                case 16:
                                    tarief = new ZorgTogAfgeleidNietGecontracteerdTarief(reader2);
                                    break;
                                case 17:
                                    tarief = new ZorgTogVrijGecontracteerdTarief(reader2);
                                    break;
                                case 19:
                                    tarief = new ZorgTogAfgeleidToeslagTarief(reader2);
                                    break;
                                case 20:
                                    tarief = new ZorgTogBeperkendGecontracteerdTarief(reader2);
                                    break;
                                default://21
                                    tarief = new ZorgTogKortingsTarief(reader2);
                                    break;
                            }
                            tarief.Bedrag = (long)reader2[nameof(tarief.Bedrag)];
                            tarief.Begindatum = reader2[nameof(tarief.Begindatum)].ToString();
                            tarief.Einddatum = reader2[nameof(tarief.Einddatum)].ToString();
                            tarief.Importdatum = reader2[nameof(tarief.Importdatum)].ToString();
                            tarief.IndicatieDebetCredit = reader2[nameof(tarief.IndicatieDebetCredit)].ToString();
                            tarief.Vervaldatum = reader2[nameof(tarief.Vervaldatum)].ToString();
                            

                            tariefWereld.tarieven.Add(tarief);
                        }
                    }

                    //----------------------------------mongo part

                    BsonDocument doc = tariefWereld.toJSON();
                    mongo.insert(doc);
                }
            }
        }
    }
}
