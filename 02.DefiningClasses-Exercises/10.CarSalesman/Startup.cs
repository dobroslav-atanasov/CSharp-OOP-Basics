namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string model = inputParts[0];
                int power = int.Parse(inputParts[1]);
                Engine engine = new Engine(model, power);
                if (inputParts.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(inputParts[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = inputParts[2];
                    }
                }
                else if (inputParts.Length == 4)
                {
                    int displacement = int.Parse(inputParts[2]);
                    string efficiency = inputParts[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string model = inputParts[0];
                string engineModel = inputParts[1];
                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
                Car car = new Car(model, engine);
                if (inputParts.Length == 3)
                {
                    int weight;
                    if (int.TryParse(inputParts[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = inputParts[2];
                    }
                }
                else if (inputParts.Length == 4)
                {
                    int weight = int.Parse(inputParts[2]);
                    string color = inputParts[3];
                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}