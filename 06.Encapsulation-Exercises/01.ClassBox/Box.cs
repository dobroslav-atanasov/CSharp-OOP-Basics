namespace ClassBox
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public void CalculateSurfaceArea()
        {
            double area = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
            Console.WriteLine($"Surface Area - {area:F2}");
        }

        public void CalculateLateralArea()
        {
            double area = 2 * this.length * this.height + 2 * this.width * this.height;
            Console.WriteLine($"Lateral Surface Area - {area:F2}");
        }

        public void CalculateVolume()
        {
            double volume = this.length * this.width * this.height;
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}