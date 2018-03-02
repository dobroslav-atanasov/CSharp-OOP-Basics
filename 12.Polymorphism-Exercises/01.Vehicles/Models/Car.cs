using System;

public class Car : Vehicle
{
    private const double ACConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        double neededFuel = distance * (base.FuelConsumption + ACConsumption);
        if (neededFuel <= base.FuelQuantity)
        {
            base.FuelQuantity -= neededFuel;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"Car needs refueling");
        }
    }

    public override void Refuel(double liters)
    {
        base.FuelQuantity += liters;
    }
}