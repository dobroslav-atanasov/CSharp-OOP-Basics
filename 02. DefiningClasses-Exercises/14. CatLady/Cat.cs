namespace CatLady
{
    public abstract class Cat
    {
        private string name;

        protected Cat(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}