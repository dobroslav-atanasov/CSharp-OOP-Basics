using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p.ToString()));
    }
}