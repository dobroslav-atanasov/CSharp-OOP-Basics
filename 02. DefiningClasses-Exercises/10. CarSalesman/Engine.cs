namespace CarSalesman
{
    using System.Text;

    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }

        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}");
            if (this.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().Trim();
        }
    }
}