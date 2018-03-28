using System.Text;

public class ShowCar : Car
{
    private int stars;
    
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
        int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get { return this.stars; }
        set { this.stars = value; }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .Append($"{this.Stars} *");
        return sb.ToString();
    }
}