using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(lapsNumber, trackLength);

        string input = Console.ReadLine();
        while (true)
        {
            List<string> inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputParts[0];
            inputParts.Remove(inputParts[0]);
            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(inputParts);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string result = this.raceTower.CompleteLaps(inputParts);
                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(inputParts);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(inputParts);
                    break;
            }

            if (this.raceTower.hasWinner)
            {
                Console.WriteLine($"{this.raceTower.winner.Name} wins the race for {this.raceTower.winner.TotalTime:F3} seconds.");
                return;
            }
            input = Console.ReadLine();
        }
    }
}