public class EarthMonument : Monument
{
    private int earthAffnity;
    
    public EarthMonument(string name, int earthAffnity) 
        : base(name)
    {
        this.EarthAffnity = earthAffnity;
    }

    public int EarthAffnity
    {
        get { return this.earthAffnity; }
        set { this.earthAffnity = value; }
    }

    public override double GetMomumentPower()
    {
        return this.EarthAffnity;
    }

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffnity}";
    }
}