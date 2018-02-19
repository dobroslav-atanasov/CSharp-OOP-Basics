using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
            persons.Add(person);
        }
        double bonus = double.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}