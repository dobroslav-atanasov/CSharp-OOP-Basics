namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;
        private int rating;

        public Team(string name)
        {
            this.name = name;
            this.players = new Dictionary<string, Player>();
        }

        public int Rating
        {
            get { return this.CalculateRating(); }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value; this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            if (!this.players.ContainsKey(player.Name))
            {
                this.players[player.Name] = player;
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.ContainsKey(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
            }
            else
            {
                this.players.Remove(playerName);
            }
        }

        private int CalculateRating()
        {
            if (this.players.Count != 0)
            {
                return (int)this.players.Average(r => r.Value.Rating);
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}