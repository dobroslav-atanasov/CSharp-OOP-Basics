public class AirBender : Bender
{
    private double aerialIntegrity;
    
    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return this.aerialIntegrity; }
        set { this.aerialIntegrity = value; }
    }

    public override double GetBenderPower()
    {
        return base.Power * this.AerialIntegrity;
    }

    public double GetTotalPower()
    {
        return base.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:F2}";
    }
}