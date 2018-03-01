using System;

public class Startup
{
    public static void Main()
    {
        try
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(5, 5);

            Console.WriteLine(circle);
            Console.WriteLine(rectangle);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}