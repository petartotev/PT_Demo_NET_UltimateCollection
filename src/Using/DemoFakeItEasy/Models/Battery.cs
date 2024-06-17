using DemoFakeItEasy.Models.Interfaces;

namespace DemoFakeItEasy.Models;

public class Battery : IBattery
{
    public bool IsCharged()
    {
        return new Random().Next(1, 101) <= 50;
    }
}
