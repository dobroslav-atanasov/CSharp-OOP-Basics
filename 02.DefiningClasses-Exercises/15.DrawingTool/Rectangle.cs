namespace DrawingTool
{
    using System;

    public class Rectangle : Shape
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
            set { this.height = value; }
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public override void Draw()
        {
            Console.WriteLine($"|{new string('-', this.Width)}|");
            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.Width)}|");
            }
            Console.WriteLine($"|{new string('-', this.Width)}|");
        }
    }
}