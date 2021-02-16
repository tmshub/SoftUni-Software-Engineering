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

        public Person[] GetPeople()
        {
            var people = Peoples.Where(a => a.Age > 30)
              .OrderBy(n => n.Name)
              .ToArray();

            return people;
        }
    }
}
