using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string animalType = Console.ReadLine();
        while (animalType != "Beast!")
        {
            string[] animalParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                ParseAnimal(animals, animalType, animalParts);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            animalType = Console.ReadLine();
        }

        PrintAnimals(animals);
    }

    private static void PrintAnimals(List<Animal> animals)
    {
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ParseAnimal(List<Animal> animals, string animalType, string[] animalParts)
    {
        switch (animalType.ToLower())
        {
            case "dog":
                Dog dog = new Dog(animalParts[0], int.Parse(animalParts[1]), animalParts[2]);
                animals.Add(dog);
                break;
            case "cat":
                Cat cat = new Cat(animalParts[0], int.Parse(animalParts[1]), animalParts[2]);
                animals.Add(cat);
                break;
            case "frog":
                Frog frog = new Frog(animalParts[0], int.Parse(animalParts[1]), animalParts[2]);
                animals.Add(frog);
                break;
            case "kitten":
                Kitten kitten = new Kitten(animalParts[0], int.Parse(animalParts[1]));
                animals.Add(kitten);
                break;
            case "tomcat":
                Tomcat tomcat = new Tomcat(animalParts[0], int.Parse(animalParts[1]));
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}