namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                if (!people.ContainsKey(name))
                {
                    people[name] = new Person(name);
                }

                switch (inputParts[1])
                {
                    case "company":
                        string companyName = inputParts[2];
                        string department = inputParts[3];
                        decimal salary = decimal.Parse(inputParts[4]);
                        Company company = new Company(companyName, department, salary);
                        people[name].Company = company;
                        break;
                    case "pokemon":
                        string pokemonName = inputParts[2];
                        string type = inputParts[3];
                        Pokemon pokemon = new Pokemon(pokemonName, type);
                        people[name].Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        string parentName = inputParts[2];
                        string parentBirthday = inputParts[3];
                        Parent parent = new Parent(parentName, parentBirthday);
                        people[name].Parents.Add(parent);
                        break;
                    case "children":
                        string childName = inputParts[2];
                        string childBirthday = inputParts[3];
                        Child child = new Child(childName, childBirthday);
                        people[name].Children.Add(child);
                        break;
                    case "car":
                        string model = inputParts[2];
                        int speed = int.Parse(inputParts[3]);
                        Car car = new Car(model, speed);
                        people[name].Car = car;
                        break;
                }
                input = Console.ReadLine();
            }

            string searchedName = Console.ReadLine();
            Person person = people.Values.FirstOrDefault(p => p.Name == searchedName);
            Console.WriteLine(person);
        }
    }
}