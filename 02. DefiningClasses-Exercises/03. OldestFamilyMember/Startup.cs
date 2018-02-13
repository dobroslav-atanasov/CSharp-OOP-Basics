using System;

public class Startup
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < number; i++)
        {
            string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string name = inputParts[0];
            int age = int.Parse(inputParts[1]);
            Person person = new Person(name, age);
            family.AddMember(person);
        }

        Person oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}