namespace Google
{
    public class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}";
        }
    }
}