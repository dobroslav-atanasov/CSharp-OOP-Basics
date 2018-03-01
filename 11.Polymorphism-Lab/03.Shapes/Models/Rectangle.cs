using System.Text;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            Validator.CheckDimension(value, nameof(this.Height));
            this.height = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            Validator.CheckDimension(value, nameof(this.Width));
            this.width = value;
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * this.Width + 2 * this.Height;
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override string Draw()
    {
        return base.Draw() + " Rectangle";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Rectangle:")
            .AppendLine($" - perimeter: {this.CalculatePerimeter():F2}")
            .AppendLine($" - area: {this.CalculateArea():F2}")
            .Append(this.Draw());
        return sb.ToString();
    }
}