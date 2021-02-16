using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StarUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family peoples = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] members = Console.ReadLine().Split();

                string name = members[0];
                int age = int.Parse(members[1]);
                Person person = new Person(name, age);
                peoples.AddMember(person);
            }

            Person[] persons = peoples.GetPeople();

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
