namespace RawData
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
                int speed = int.Parse(inputParts[1]);
                int power = int.Parse(inputParts[2]);
                int weight = int.Parse(inputParts[3]);
                string type = inputParts[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                List<Tire> tires = new List<Tire>();
                for (int t = 5; t < inputParts.Length - 1; t += 2)
                {
                    double pressure = double.Parse(inputParts[t]);
                    double age = double.Parse(inputParts[t + 1]);
                    Tire tire = new Tire(pressure, age);
                    tires.Add(tire);
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    cars.Where(c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1))
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
                case "flamable":
                    cars.Where(c => c.Cargo.Type == command && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
            }
        }
    }
}