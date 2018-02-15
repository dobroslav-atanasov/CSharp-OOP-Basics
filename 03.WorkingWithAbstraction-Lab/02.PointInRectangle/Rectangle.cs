namespace PointInRectangle
{
    using System;

    public class Rectangle
    {
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
            this.BottomRightX = bottomRightX;
            this.BottomRightY = bottomRightY;
        }

        public int TopLeftX { get; set; }

        public int TopLeftY { get; set; }

        public int BottomRightX { get; set; }

        public int BottomRightY { get; set; }

        public void Contains(Point point)
        {
            bool isContains = this.TopLeftX <= point.X && point.X <= this.BottomRightX && this.TopLeftY <= point.Y && point.Y <= this.BottomRightY;
            Console.WriteLine(isContains);
        }
    }
}