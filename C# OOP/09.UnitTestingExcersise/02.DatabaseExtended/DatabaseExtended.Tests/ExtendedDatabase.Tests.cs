using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person person;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            person = new Person(1, "Qnko");
        }

        [Test]
        public void Test_WhenAddPeopleWithEqualsNames_ShouldThrowEcxeption()
        {
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Qnko")));
        }

        [Test]
        public void Test_WhenAddPeopleWithEqualsIds_ShouldThrowEcxeption()
        {
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Gosho")));
        }


        [Test]
        public void Test_WhenAddMorePeopleThan16_ShouldThrowEcxeption()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"Person{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(16, "Gosho")));
        }
        
        [Test]

        public void Test_WhenAddPersonCheckCountIsValid_ShouldReturnCorrectCount()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"Person{i}"));
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }


        [Test]

        public void Test_RemoveWhenDataBaseIsEmpty_ShouldThorowException()
        {
            
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Test_CountWhenRemoveFromDataBase_ShouldReturnCorrectCount()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"Person{i}"));
            }

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(n-1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_CheckTheUsernameIsNullOrEmpty_ShouldReturnException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }

        [Test]
        public void Test_FindUserByUsername_ShouldReturnException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Username"));
        }

        [Test]
        public void Test_FindUserByWrongId_ShouldReturnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void Test_FindUserById_ShouldReturnException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        [Test]
        public void Test_FindUserByNameWhenUserExist_ShouldReturnUser()
        {
            Person person = new Person(1, "joni");
            database.Add(person);
            Assert.That(() => database.FindByUsername("joni"), Is.EqualTo(person));
        }

        [Test]
        public void Test_FindUserByIdWhenUserExist_ShouldReturnUser()
        {
            Person person = new Person(1, "joni");
            database.Add(person);
            Assert.That(() => database.FindById(1), Is.EqualTo(person));
        }

        [Test]
        public void Test_ConstructorWhenCpacityIsExceeded_ShouldReturnException()
        {
            int n = 18;
            Person[] persons = new Person[18];

            for (int i = 0; i < n; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Test_ConstructorCpacityIsCorrectly_ShouldReturnUser()
        {
            int n = 5;
            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }

            database = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(database.Count, Is.EqualTo(persons.Length));
        }
    }
}