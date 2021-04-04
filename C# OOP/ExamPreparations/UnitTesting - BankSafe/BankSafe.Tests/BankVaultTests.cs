using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Mincho", "perka");
        }

        [Test]
        public void Test1()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("Q9", item));
        }

        [Test]
        public void Test2()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item));
        }

        [Test]
        public void Test3()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void Test4()
        {
            Assert.That(bankVault.AddItem("A1", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void Test5()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("Q9", item));
        }
        [Test]
        public void Test6()
        {
            bankVault.AddItem("A1", item);
            Item item2 = new Item("Gosho", "Magnit");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item2));
        }
        [Test]
        public void Test7()
        {
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }
    }
}