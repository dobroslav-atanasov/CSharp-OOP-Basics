namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputParts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0];
                string teamName = inputParts[1];
                try
                {
                    switch (command.ToLower())
                    {
                        case "team":
                            teams.Add(teamName, new Team(teamName));
                            break;
                        case "add":
                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Player player = new Player(inputParts[2], int.Parse(inputParts[3]), int.Parse(inputParts[4]),
                                int.Parse(inputParts[5]), int.Parse(inputParts[6]), int.Parse(inputParts[7]));
                            teams[teamName].AddPlayer(player);
                            break;
                        case "remove":
                            string playerName = inputParts[2];
                            teams[teamName].RemovePlayer(playerName);
                            break;
                        case "rating":
                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Console.WriteLine(teams[teamName]);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}