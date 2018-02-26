using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Food> foods = new List<Food>();
        string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string foodName in inputParts)
        {
            Food food = FoodFactory.GetFood(foodName);
            foods.Add(food);
        }

        Mood mood = MoodFactory.GetMood(foods);
        Console.WriteLine(foods.Sum(f => f.PointsOfHappiness));
        Console.WriteLine(mood);
    }
}