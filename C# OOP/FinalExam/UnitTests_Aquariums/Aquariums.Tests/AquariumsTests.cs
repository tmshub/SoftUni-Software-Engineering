namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {

        [Test]
        public void test1()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 10);
            Fish fish = new Fish("Misho");

            Assert.That(fish.Name, Is.EqualTo("Misho"));
            Assert.That(aquarium.Name, Is.EqualTo("MyAquarium"));
            Assert.That(aquarium.Capacity, Is.EqualTo(10));
            Assert.That(aquarium.Count, Is.EqualTo(0));
            
        }

        [Test]
        public void TestName()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 10);
            
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(null, 10));
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium("", 10));
            aquarium = new Aquarium("Misho", 10);
            Assert.That(aquarium.Name, Is.EqualTo("Misho"));
        }

        [Test]
        public void TestCapacity()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 10);

            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Misho", -2));
            aquarium = new Aquarium("Mis", 10);
            Assert.That(aquarium.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void TestAddMethod()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 2);
            Fish fish = new Fish("Misho");

            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
            aquarium.Add(new Fish("Penko"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Gosho")));
            
        }

        [Test]
        public void TestRemoveMethod()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 2);
            Fish fish = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(new Fish("Penko"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Tosho"));
            aquarium.RemoveFish("Penko");
            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void TestSellFishMethod()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 2);
            Fish fish = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(new Fish("Penko"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Tosho"));
            Assert.That(() => aquarium.SellFish("Misho"), Is.EqualTo(fish));
            Assert.That(fish.Available, Is.False);
        }

        [Test]
        public void TestReportMethod()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 4);
            Fish fish = new Fish("Misho");
            aquarium.Add(fish);
            aquarium.Add(new Fish("Macho"));
            aquarium.Add(new Fish("Daaaa"));

            Assert.That(() => aquarium.Report(), Is.EqualTo("Fish available at MyAquarium: Misho, Macho, Daaaa"));

        }
    }
}
