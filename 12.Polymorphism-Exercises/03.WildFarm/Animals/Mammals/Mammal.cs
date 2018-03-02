public abstract class Mammal : Animal
{
    private string livingRegion;
    
    protected Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return this.livingRegion; }
        set { this.livingRegion = value; }
    }
}