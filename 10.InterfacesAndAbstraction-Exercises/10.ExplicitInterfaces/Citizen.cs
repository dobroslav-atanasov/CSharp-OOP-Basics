using System;

public class Citizen : IPerson, IResident
{
    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    public string Name { get; }

    public string Country { get; }

    public int Age { get; }

    void IResident.GetName()
    {
        Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
    }

    void IPerson.GetName()
    {
        Console.WriteLine($"{this.Name}");
    }
}