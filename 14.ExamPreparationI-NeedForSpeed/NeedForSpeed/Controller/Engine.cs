using System;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Start()
    {
        string input = Console.ReadLine();
        while (input != "Cops Are Here")
        {
            string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputParts[0];
            switch (command)
            {
                case "register":
                    this.carManager.Register(int.Parse(inputParts[1]), inputParts[2], inputParts[3], inputParts[4], int.Parse(inputParts[5]), int.Parse(inputParts[6]),
                        int.Parse(inputParts[7]), int.Parse(inputParts[8]), int.Parse(inputParts[9]));
                    break;
                case "check":
                    Console.WriteLine(carManager.Check(int.Parse(inputParts[1])));
                    break;
                case "open":
                    if (inputParts.Length == 6)
                    {
                        this.carManager.Open(int.Parse(inputParts[1]), inputParts[2], int.Parse(inputParts[3]), inputParts[4], int.Parse(inputParts[5]));
                    }
                    else
                    {
                        this.carManager.OpenSpecialRace(int.Parse(inputParts[1]), inputParts[2], int.Parse(inputParts[3]), inputParts[4], int.Parse(inputParts[5]), int.Parse(inputParts[6]));
                    }
                    break;
                case "participate":
                    this.carManager.Participate(int.Parse(inputParts[1]), int.Parse(inputParts[2]));
                    break;
                case "start":
                    Console.WriteLine(carManager.Start(int.Parse(inputParts[1])));
                    break;
                case "park":
                    this.carManager.Park(int.Parse(inputParts[1]));
                    break;
                case "unpark":
                    this.carManager.Unpark(int.Parse(inputParts[1]));
                    break;
                case "tune":
                    this.carManager.Tune(int.Parse(inputParts[1]), inputParts[2]);
                    break;
            }
            input = Console.ReadLine();
        }
    }
}