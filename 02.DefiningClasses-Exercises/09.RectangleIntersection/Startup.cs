namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputRectangle = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int numberOfRectangles = inputRectangle[0];
            int numberOfChecks = inputRectangle[1];
            Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string id = parts[0];
                double width = double.Parse(parts[1]);
                double height = double.Parse(parts[2]);
                double xTopLeft = double.Parse(parts[3]);
                double yTopLeft = double.Parse(parts[4]);
                Rectangle rectangle = new Rectangle(id, width, height, xTopLeft, yTopLeft);
                if (!rectangles.ContainsKey(id))
                {
                    rectangles[id] = rectangle;
                }
            }

            for (int i = 0; i < numberOfChecks; i++)
            {
                string[] inputChecks = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string firstId = inputChecks[0];
                string secondId = inputChecks[1];
                Rectangle firstRectangle = rectangles[firstId];
                Rectangle secondRectangle = rectangles[secondId];
                Console.WriteLine(
                    firstRectangle.CheckIntersection(firstRectangle, secondRectangle).ToString().ToLower());
            }
        }
    }
}