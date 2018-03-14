public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        protected set { this.fuelConsumptionPerKm = value; }
    }

    public Car Car
    {
        get { return this.car; }
        protected set { this.car = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}