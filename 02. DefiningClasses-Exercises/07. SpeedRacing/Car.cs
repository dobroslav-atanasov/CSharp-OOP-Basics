namespace SpeedRacing
{
    using System;

    public class Car
    {
        private string model;
        private double amountOfFuel;
        private double fuelConsumption;
        private int distance;

        public Car(string model, double amountOfFuel, double fuelConsumption)
        {
            this.Model = model;
            this.AmountOfFuel = amountOfFuel;
            this.FuelConsumption = fuelConsumption;
            this.Distance = 0;
        }

        public int Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double AmountOfFuel
        {
            get { return this.amountOfFuel; }
            set { this.amountOfFuel = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public void Drive(int distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (neededFuel <= this.AmountOfFuel)
            {
                this.AmountOfFuel -= neededFuel;
                this.Distance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.AmountOfFuel:F2} {this.Distance}";
        }
    }
}