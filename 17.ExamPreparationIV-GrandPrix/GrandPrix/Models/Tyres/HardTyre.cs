public class HardTyre : Tyre
{
    public HardTyre(double hardness) 
        : base(hardness)
    {
        this.Name = "Hard";
    }

    public override string Name { get; }
}