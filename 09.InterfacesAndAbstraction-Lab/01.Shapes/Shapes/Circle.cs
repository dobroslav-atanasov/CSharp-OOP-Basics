using System;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.Radius = radius;
    }   

    public int Radius
    {
        get { return this.radius; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Radius must be positive!");
            }
            this.radius = value;
        }
    }

    public void Draw()
    {
        double innerRadius = this.Radius - 0.4;
        double outsideRadius = this.Radius + 0.4;

        for (double i = this.Radius; i >= -this.Radius; --i)
        {
            for (double j = -this.Radius; j < outsideRadius; j += 0.5)
            {
                double value = i * i + j * j;
                if (value >= innerRadius * innerRadius && value <= outsideRadius * outsideRadius)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}