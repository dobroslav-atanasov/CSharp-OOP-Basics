using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height must be positive!");
            }
            this.height = value;
        }
    }

    public int Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width must be positive!");
            }
            this.width = value;
        }
    }

    public void Draw()
    {
        Console.WriteLine(new string('*', this.Width));
        for (int row = 1; row < this.Height - 1; row++)
        {
            Console.Write("*");
            for (int i = 1; i < this.Width - 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("*");
        }
        Console.WriteLine(new string('*', this.Width));
    }
}