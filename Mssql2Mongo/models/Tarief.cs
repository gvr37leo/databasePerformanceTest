using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mssql2Mongo.models {
    abstract class Tarief {
        public abstract short discriminator { get; }
        public string Begindatum;
        public string Einddatum;
        public string Vervaldatum;
        public string Importdatum;
        public string IndicatieDebetCredit;
        public long Bedrag;

        public BsonDocument toJSON(){
            return completeJSON(new BsonDocument{
                {"class",discriminator},
                {nameof(Begindatum), Begindatum },
                {nameof(Einddatum), Einddatum },
                {nameof(Vervaldatum), Vervaldatum },
                {nameof(Importdatum), Importdatum },
                {nameof(IndicatieDebetCredit), IndicatieDebetCredit },
                {nameof(Bedrag), Bedrag },
            });
        }

        public abstract BsonDocument completeJSON(BsonDocument bsonDocument);
    }
}
