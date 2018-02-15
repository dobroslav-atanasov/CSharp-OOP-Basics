namespace OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                int age = int.Parse(inputParts[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            people.Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}