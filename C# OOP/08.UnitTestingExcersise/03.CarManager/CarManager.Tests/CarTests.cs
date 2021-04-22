
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            Car car = new Car("Make", "Astra", 10, 100);
        }

        [Test]
        [TestCase("", "Astra", 10, 100)]
        [TestCase(null, "Astra", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make",null, 10, 100)]
        [TestCase("Make","Astra", 0, 100)]
        [TestCase("Make","Astra", -4, 100)]
        [TestCase("Make","Astra", 10, -32)]
        public void Test_AllProperties_ShouldThorowException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Model", "Astra", 10, 100)]
        public void Test_AllPropertiesCorrectlySetValues_ShouldReturnSetType(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-23)]
        public void Test_CarRefuelMethod_ShouldReturnException(double quantity)
        {
            car = new Car("Make", "Astra", 10, 100);
            Assert.Throws<ArgumentException>(() => car.Refuel(quantity));
        }

        [Test]
        [TestCase(12)]
        [TestCase(1111)]
        public void Test_FuelAmountIsIncreaseCorrectly_ShouldReturnFuelAmount(double quantity)
        {
            car = new Car("Make", "Astra", 10, 100);
            car.Refuel(quantity);
            if(quantity > 100)
            {
                quantity = 100;
            }
            Assert.That(car.FuelAmount, Is.EqualTo(quantity));
        }

        [Test]
        [TestCase(1111)]
        public void Test_CarDriveMethod_ShouldReturnException(double distance)
        {
            car = new Car("Make", "Astra", 10, 100);
            
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(1)]
        public void Test_CarDriveMethod_ShouldReturnValue(double distance)
        {
            car = new Car("Make", "Astra", 10, 100);
            car.Refuel(10);
            double carAmount = 10-((distance / 100) * car.FuelConsumption);
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(carAmount));
        }
    }
}