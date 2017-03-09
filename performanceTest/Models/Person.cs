using System;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;

namespace performanceTest.Models {
    public class Person {

        private static Random random = new Random();
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstMidName { get; set; }

        public Person(){
            ID = random.Next();
            LastName = randomString();
            FirstMidName = randomString();
        }

        private string randomString(){
            

            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, 5)
                                   .Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
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
