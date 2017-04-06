using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mssql2Mongo.models {
    class TariefWereld {
        public short? Prestatiecodelijst { get; set; }
        public string DbcDeclaratiecode { get; set; }
        public long Id { get; set; }
        public List<Tarief> tarieven = new List<Tarief>();

        public BsonDocument toJSON(){
            var doc = new BsonDocument{
                {nameof(Id), Id },
                {nameof(Prestatiecodelijst),Prestatiecodelijst},
                {nameof(DbcDeclaratiecode),DbcDeclaratiecode },
                {nameof(tarieven), BsonArray.Create(tarieven.Select(tarief => tarief.toJSON()))}
            };

            return doc;
        }
    }
}
