using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Peoples = new List<Person>();
        }
        public List<Person> Peoples { get; set; }

        public void AddMember(Person member)
        {
            Peoples.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person person = new Person();

            foreach (var currentPerson in Peoples)
            {
                if (currentPerson.Age > maxAge)
                {
                    maxAge = currentPerson.Age;
                    person = currentPerson;
                }
            }

            return person;
        }
    }
}
