namespace RawData
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public List<Tire> Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
    }
}