namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double xTopLeft;
        private double yTopLeft;

        public Rectangle(string id, double width, double height, double xTopLeft, double yTopLeft)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.XTopLeft = xTopLeft;
            this.YTopLeft = yTopLeft;
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public double XTopLeft
        {
            get { return this.xTopLeft; }
            set { this.xTopLeft = value; }
        }

        public double YTopLeft
        {
            get { return this.yTopLeft; }
            set { this.yTopLeft = value; }
        }

        public bool CheckIntersection(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (firstRectangle.XTopLeft > secondRectangle.XTopLeft + secondRectangle.Width
                || secondRectangle.XTopLeft > firstRectangle.XTopLeft + firstRectangle.Width)
            {
                return false;
            }
            if (firstRectangle.YTopLeft < secondRectangle.YTopLeft - firstRectangle.Height
                || secondRectangle.YTopLeft < firstRectangle.YTopLeft - firstRectangle.height)
            {
                return false;
            }

            return true;
        }
    }
}