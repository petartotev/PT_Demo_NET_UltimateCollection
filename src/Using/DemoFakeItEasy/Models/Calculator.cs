using DemoFakeItEasy.Exceptions;
using DemoFakeItEasy.Models.Interfaces;

namespace DemoFakeItEasy.Models;

public class Calculator : ICalculator
{
    private readonly IBattery _battery;

    public Calculator(IBattery battery)
    {
        _battery = battery;
    }

    public double Add(double a, double b)
    {
        if (!_battery.IsCharged()) throw new NotEnoughEnergyException();

        return a + b;
    }

    public double Subtract(double a, double b)
    {
        if (!_battery.IsCharged()) throw new NotEnoughEnergyException();

        return a - b;
    }

    public double Multiply(double a, double b)
    {
        if (!_battery.IsCharged()) throw new NotEnoughEnergyException();

        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            if (!_battery.IsCharged()) throw new NotEnoughEnergyException();

            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return a / b;
    }
}
