namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string model = inputParts[0];
                double amountOfFuel = double.Parse(inputParts[1]);
                double fuelComsumption = double.Parse(inputParts[2]);
                Car car = new Car(model, amountOfFuel, fuelComsumption);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputParts[1];
                int distance = int.Parse(inputParts[2]);
                Car car = cars.FirstOrDefault(c => c.Model == carModel);
                car.Drive(distance);
                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}