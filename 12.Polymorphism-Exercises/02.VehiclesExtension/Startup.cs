using System;

public class Startup
{
    private static Car car;
    private static Truck truck;
    private static Bus bus;

    public static void Main()
    {
        ParseInput();
        int numberOfCommands = int.Parse(Console.ReadLine());
        ParseCommand(numberOfCommands);
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ParseInput()
    {
        string[] carParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] truckParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] busParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        car = new Car(double.Parse(carParts[1]), double.Parse(carParts[2]), double.Parse(carParts[3]));
        truck = new Truck(double.Parse(truckParts[1]), double.Parse(truckParts[2]), double.Parse(truckParts[3]));
        bus = new Bus(double.Parse(busParts[1]), double.Parse(busParts[2]), double.Parse(busParts[3]));
    }

    private static void ParseCommand(int numberOfCommands)
    {
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandParts[0];
            switch (command)
            {
                case "Drive":
                    DriveCommand(commandParts);
                    break;
                case "Refuel":
                    RefuelCommand(commandParts);
                    break;
                case "DriveEmpty":
                    bus.DriveEmpty(double.Parse(commandParts[2]));
                    break;
            }
        }
    }

    private static void RefuelCommand(string[] commandParts)
    {
        string vehicle = commandParts[1];
        switch (vehicle)
        {
            case "Car":
                car.Refuel(double.Parse(commandParts[2]));
                break;
            case "Truck":
                truck.Refuel(double.Parse(commandParts[2]));
                break;
            case "Bus":
                bus.Refuel(double.Parse(commandParts[2]));
                break;
        }
    }

    private static void DriveCommand(string[] commandParts)
    {
        string vehicle = commandParts[1];
        switch (vehicle)
        {
            case "Car":
                car.Drive(double.Parse(commandParts[2]));
                break;
            case "Truck":
                truck.Drive(double.Parse(commandParts[2]));
                break;
            case "Bus":
                bus.Drive(double.Parse(commandParts[2]));
                break;
        }
    }
}