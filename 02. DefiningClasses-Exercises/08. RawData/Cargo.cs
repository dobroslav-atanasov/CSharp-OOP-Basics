namespace RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}