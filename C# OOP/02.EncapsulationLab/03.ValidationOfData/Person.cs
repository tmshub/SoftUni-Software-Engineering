using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { 
            get => this.firstName;
            private set
            {
                if (value.Length < 3)
                {

                }

               this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (value.Length < 3)
                {

                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 1)
                {

                }

                this.age = value;
            }
        }
        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if (value<460)
                {

                }

                this.salary= value;
            }
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                percentage = percentage/2;
            }
           
          Salary = Salary + Salary * percentage / 100;
            
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
