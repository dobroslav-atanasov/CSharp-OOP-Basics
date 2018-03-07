using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private const int IncreaseHorsepower = 50;
    private const int DecreaseSuspension = 25;

    private List<string> addOns;
    
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += this.Horsepower * IncreaseHorsepower / 100;
        this.Suspension -= this.Suspension * DecreaseSuspension / 100;
    }

    public List<string> AddOns
    {
        get { return this.addOns; }
        set { this.addOns = value; }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.AddOns.Add(addOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        if (this.AddOns.Count == 0)
        {
            sb.Append("Add-ons: None");
        }
        else
        {
            sb.Append($"Add-ons: {string.Join(", ", this.AddOns)}");
        }
        return sb.ToString();
    }
}