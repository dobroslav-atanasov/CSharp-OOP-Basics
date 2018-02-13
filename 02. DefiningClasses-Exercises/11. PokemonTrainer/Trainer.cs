namespace PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}