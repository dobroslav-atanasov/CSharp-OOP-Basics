namespace DrawingTool
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "Square":
                    int size = int.Parse(Console.ReadLine());
                    Square square = new Square(size);
                    square.Draw();
                    break;
                case "Rectangle":
                    int width = int.Parse(Console.ReadLine());
                    int height = int.Parse(Console.ReadLine());
                    Rectangle rectangle = new Rectangle(width, height);
                    rectangle.Draw();
                    break;
            }
        }
    }
}