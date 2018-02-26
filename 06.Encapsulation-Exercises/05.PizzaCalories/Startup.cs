using System;

public class Startup
{
    public static void Main()
    {
        string[] inputParts = Console.ReadLine().Split();
        try
        {
            CreatePizza(inputParts);

        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void CreatePizza(string[] inputParts)
    {
        Pizza pizza = new Pizza(inputParts[1]);
        inputParts = Console.ReadLine().Split();
        Dough pizzaDough = new Dough(inputParts[1], inputParts[2], double.Parse(inputParts[3]));
        pizza.Dought = pizzaDough;
        inputParts = Console.ReadLine().Split();
        while (inputParts[0] != "END")
        {
            Topping pizzaTopping = new Topping(inputParts[1], double.Parse(inputParts[2]));
            pizza.AddTopping(pizzaTopping);
            inputParts = Console.ReadLine().Split();
        }
        if (pizza.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        Console.WriteLine(pizza);
    }
}