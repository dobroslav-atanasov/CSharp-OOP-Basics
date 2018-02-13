using System;

public class Startup
{
    public static void Main()
    {
        Person person = new Person();
        person.Name = "Ivan";
        person.Age = 20;

        Console.WriteLine($"{person.Name} {person.Age}");
    }
}