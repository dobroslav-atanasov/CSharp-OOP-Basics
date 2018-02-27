public class Rebel : IRebel, IBuyer
{
    public Rebel(string name, int age, string @group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = @group;
        this.Food = 0;
    }

    public string Name { get; }

    public int Age { get; }

    public string Group { get; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}