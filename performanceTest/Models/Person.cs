using System;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using MongoDB.Bson;

namespace performanceTest.Models {
    public class Person {

        private static Random random = new Random();
        public virtual long ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstMidName { get; set; }
        public virtual string Id { get; set; }

        public Person(){
            ID = (long) (random.NextDouble() * long.MaxValue);
            LastName = randomString();
            FirstMidName = randomString();
        }

        private string randomString(){
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, 5)
                                   .Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        public virtual BsonDocument ToBsonDocument(){
            var doc = new BsonDocument();
            doc.Set(nameof(ID), ID);
            doc.Set(nameof(LastName), LastName);
            doc.Set(nameof(FirstMidName), FirstMidName);
            return doc;
        }
    }

    public class PersonMap: ClassMapping<Person>{
        public PersonMap(){
            Id(person => person.ID);
            Property(person => person.FirstMidName);
            Property(person => person.LastName);
        }
    }
}
