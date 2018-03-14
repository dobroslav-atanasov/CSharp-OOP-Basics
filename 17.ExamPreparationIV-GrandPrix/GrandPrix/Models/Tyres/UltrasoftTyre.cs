using System;

public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        this.Grip = grip;
        this.Name = "Ultrasoft";
    }

    public double Grip
    {
        get { return this.grip; }
        set { this.grip = value; }
    }

    public override double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public override string Name { get; }

    public override void ReducedDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}