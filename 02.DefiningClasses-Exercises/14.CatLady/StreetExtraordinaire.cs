namespace CatLady
{
    public class StreetExtraordinaire : Cat
    {
        private double decibelsOfMeows;

        public StreetExtraordinaire(string name, double decibelsOfMeows)
            : base(name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public double DecibelsOfMeows
        {
            get { return this.decibelsOfMeows; }
            set { this.decibelsOfMeows = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.DecibelsOfMeows}";
        }
    }
}