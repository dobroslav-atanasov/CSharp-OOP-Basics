using System.Text;

public abstract class Car
{
    private const int HalfIndex = 50;
    
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int Durability
    {
        get { return this.durability; }
        set { this.durability = value; }
    }

    public int Suspension
    {
        get { return this.suspension; }
        set { this.suspension = value; }
    }

    public int Acceleration
    {
        get { return this.acceleration; }
        set { this.acceleration = value; }
    }   

    public int Horsepower
    {
        get { return this.horsepower; }
        set { this.horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        set { this.yearOfProduction = value; }
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Brand
    {
        get { return this.brand; }
        set { this.brand = value; }
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex * HalfIndex / 100;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .Append($"{this.Suspension} Suspension force, {this.Durability} Durability");
        return sb.ToString();
    }
}