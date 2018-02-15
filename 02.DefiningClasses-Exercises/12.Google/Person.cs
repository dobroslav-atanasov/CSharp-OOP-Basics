namespace Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;
        private Car car;

        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public Car Car
        {
            get { return this.car; }
            set { this.car = value; }
        }

        public List<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public List<Parent> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public Company Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name)
                .AppendLine("Company:");
            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }

            sb.AppendLine("Car:");
            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }

            sb.AppendLine("Pokemon:");
            if (this.Pokemons.Count != 0)
            {
                foreach (Pokemon pokemon in this.Pokemons)
                {
                    sb.AppendLine(pokemon.ToString());
                }
            }

            sb.AppendLine("Parents:");
            if (this.Parents.Count != 0)
            {
                foreach (Parent parent in this.Parents)
                {
                    sb.AppendLine(parent.ToString());
                }
            }

            sb.AppendLine("Children:");
            if (this.Children.Count != 0)
            {
                foreach (Child child in this.Children)
                {
                    sb.AppendLine(child.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}