using DemoFakeItEasy.Exceptions;
using DemoFakeItEasy.Models;
using DemoFakeItEasy.Models.Interfaces;
using FakeItEasy;
using FluentAssertions;

namespace DemoFakeItEasy.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Calculator_WithChargedBattery_ShouldAddCorrectly()
        {
            // Arrange
            var battery = A.Fake<IBattery>();
            A.CallTo(() => battery.IsCharged()).Returns(true);
            var calculator = new Calculator(battery);

            // Act
            var result = calculator.Add(5, 3);

            // Assert
            result.Should().Be(8);
        }

        [Test]
        public void Calculator_WithDeadBattery_ShouldThrowNotEnoughEnergyException()
        {
            // Arrange
            var battery = A.Fake<IBattery>();
            A.CallTo(() => battery.IsCharged()).Returns(false);
            var calculator = new Calculator(battery);

            // Act & Assert
            Assert.Throws<NotEnoughEnergyException>(() => calculator.Add(5, 3));
        }

        [Test]
        public void Calculator_WithBatteryIsChargedThrowingException_ShouldRethrowException()
        {
            // Arrange
            var battery = A.Fake<IBattery>();
            A.CallTo(() => battery.IsCharged()).Throws<InvalidOperationException>();
            var calculator = new Calculator(battery);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => calculator.Add(5, 3));
        }
    }
}