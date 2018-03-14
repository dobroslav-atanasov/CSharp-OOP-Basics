public class AggressiveDriver : Driver
{
    private const double AggressiveDriverFuelConsumption = 2.7;
    private const double AggressiveDriverSpeed = 1.3;

    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        this.FuelConsumptionPerKm = AggressiveDriverFuelConsumption;
    }

    public override double Speed => base.Speed * AggressiveDriverSpeed;
}