public abstract class Feline : Mammal
{
    private string breed;
    
    protected Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }
}