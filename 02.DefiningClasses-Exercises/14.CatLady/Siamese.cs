namespace CatLady
{
    public class Siamese : Cat
    {
        private double earSize;

        public Siamese(string name, double earSize)
            : base(name)
        {
            this.EarSize = earSize;
        }

        public double EarSize
        {
            get { return this.earSize; }
            set { this.earSize = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.EarSize}";
        }
    }
}