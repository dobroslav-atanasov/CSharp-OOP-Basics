public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public abstract void Drive(double distance);

    public abstract void Refuel(double liters);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}