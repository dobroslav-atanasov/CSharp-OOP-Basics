using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<IBuyer> buyers = new List<IBuyer>();
        ParseInput(buyers);
        BuyFoodFromAll(buyers);
        GetTotalMoney(buyers);
    }

    private static void GetTotalMoney(List<IBuyer> buyers)
    {
        int totalMoney = buyers.Sum(b => b.Food);
        Console.WriteLine(totalMoney);
    }

    private static void BuyFoodFromAll(List<IBuyer> buyers)
    {
        string name = Console.ReadLine();
        while (name != "End")
        {
            foreach (IBuyer buyer in buyers)
            {
                if (buyer.Name == name)
                {
                    buyer.BuyFood();
                }
            }
            name = Console.ReadLine();
        }
    }

    private static void ParseInput(List<IBuyer> buyers)
    {
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputParts.Length == 4)
            {
                IBuyer citizen = new Citizen(inputParts[0], int.Parse(inputParts[1]), inputParts[2], inputParts[3]);
                buyers.Add(citizen);
            }
            else if (inputParts.Length == 3)
            {
                IBuyer rebel = new Rebel(inputParts[0], int.Parse(inputParts[1]), inputParts[2]);
                buyers.Add(rebel);
            }
        }
    }
}