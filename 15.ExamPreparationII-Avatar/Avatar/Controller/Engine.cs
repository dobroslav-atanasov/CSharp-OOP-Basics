using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string input = Console.ReadLine();
        while (true)
        {
            List<string> inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputParts[0];
            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(inputParts);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(inputParts);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(inputParts[1]));
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(inputParts[1]);
                    break;
                case "Quit":
                    Console.WriteLine(this.nationsBuilder.GetWarsRecord());
                    return;
            }
            input = Console.ReadLine();
        }
    }
}