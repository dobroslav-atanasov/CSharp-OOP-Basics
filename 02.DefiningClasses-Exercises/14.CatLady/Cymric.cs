namespace CatLady
{
    public class Cymric : Cat
    {
        private double furLength;

        public Cymric(string name, double furLength)
            : base(name)
        {
            this.FurLength = furLength;
        }

        public double FurLength
        {
            get { return this.furLength; }
            set { this.furLength = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.FurLength:F2}";
        }
    }
}