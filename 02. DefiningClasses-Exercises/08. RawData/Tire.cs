namespace RawData
{
    public class Tire
    {
        private double pressure;
        private double age;

        public Tire(double pressure, double age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
    }
}