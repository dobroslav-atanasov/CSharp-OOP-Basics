using System;

public class Startup
{
    public static void Main()
    {
        Person person = new Person("Ivan", 20);
        Console.WriteLine($"{person.Name} {person.Age}");
    }
}