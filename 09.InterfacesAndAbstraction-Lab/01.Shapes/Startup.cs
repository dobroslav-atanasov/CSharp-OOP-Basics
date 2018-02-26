using System;

public class Startup
{
    public static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        try
        {
            IDrawable circle = new Circle(radius);
            IDrawable rectangle = new Rectangle(width, height);
            circle.Draw();
            rectangle.Draw();
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}