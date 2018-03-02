using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        List<Food> foods = new List<Food>();

        ReadAndParseInput(animals, foods);
        AnimalsMakeSound(animals, foods);
        PrintInfo(animals);
    }

    private static void PrintInfo(IEnumerable<Animal> animals)
    {
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void AnimalsMakeSound(List<Animal> animals, List<Food> foods)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine(animals[i].MakeSound());
            animals[i].Eat(foods[i]);
        }
    }

    private static void ReadAndParseInput(List<Animal> animals, List<Food> foods)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] animalParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] foodParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Animal animal = AnimalFactory.GetAnimal(animalParts);
            Food food = FoodFactory.GetFood(foodParts);
            animals.Add(animal);
            foods.Add(food);
            input = Console.ReadLine();
        }
    }
}