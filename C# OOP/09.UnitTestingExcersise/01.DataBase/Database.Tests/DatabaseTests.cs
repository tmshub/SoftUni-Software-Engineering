using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {

            database = new Database.Database();
        }
        [Test]
        public void Test1()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 2, 4, 5, 6, 7, 7, 3, 2, 4, 5, 6, 5, 3, 2, 4));

        }
        [Test]
        public void Test2()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(i);
                }
            });
        }

        [Test]

        public void Test3()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(1);
                database.Add(2);
                database.Add(3);
                database.Add(4);

                for (int i = 0; i < 6; i++)
                {
                    database.Remove();
                }
            });
        }

        [Test]

        public void Test4()
        {
            int element = 123;
            database.Add(element);
            int[] arr = database.Fetch();

            Assert.That(arr.Contains(element));
        }

        [Test]

        public void Test5()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            
            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]

        public void Test6()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(1);
            }

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(n - 1));
        }

        [Test]

        public void Test7()
        {
            int n = 5;

            for (int i = 0; i <= n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            int[] arr = database.Fetch();

            Assert.IsFalse(arr.Contains(5));
        }
    }
}