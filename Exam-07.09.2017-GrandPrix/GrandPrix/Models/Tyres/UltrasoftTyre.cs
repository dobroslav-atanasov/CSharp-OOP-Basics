using System;

public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;
    
    public UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get { return this.grip; }
        private set { this.grip = value; }
    }

    public override double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(ErrorMessage.BlownTyre);
            }
            this.degradation = value;
        }
    }

    public override void ReducedDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}