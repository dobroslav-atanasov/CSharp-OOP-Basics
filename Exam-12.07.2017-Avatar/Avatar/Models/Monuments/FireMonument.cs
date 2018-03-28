public class FireMonument : Monument
{
    private int fireAffinity;
    
    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return this.fireAffinity; }
        set { this.fireAffinity = value; }
    }

    public override double GetMomumentPower()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}