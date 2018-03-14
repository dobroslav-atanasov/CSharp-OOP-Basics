using System;

public class Car
{
    private const double MaxTankCapacity = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            if (value > MaxTankCapacity)
            {
                this.fuelAmount = MaxTankCapacity;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public void Refuel(double liters)
    {
        this.FuelAmount += liters;
    }

    public void ChangeTyres(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void ReduceFuel(int length, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= length * fuelConsumptionPerKm;
    }
}