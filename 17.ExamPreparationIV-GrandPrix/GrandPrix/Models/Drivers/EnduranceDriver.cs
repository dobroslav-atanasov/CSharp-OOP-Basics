public class EnduranceDriver : Driver
{
    private const double EnduranceDriverFuelConsumption = 1.5;

    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
        this.FuelConsumptionPerKm = EnduranceDriverFuelConsumption;
    }
}