using System.Text;

public class Dog : Animal
{
    public Dog(string name, string favouriteFood) 
        : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ExplainMyself())
            .Append("DJAAF");
        return sb.ToString();
    }
}