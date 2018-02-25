namespace PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputParts = input.Split();
                string ingredient = inputParts[0];
                try
                {
                    switch (ingredient)
                    {
                        case "Dough":
                            Dough dough = new Dough(inputParts[1], inputParts[2], double.Parse(inputParts[3]));
                            Console.WriteLine($"{dough.Calories:F2}");
                            break;
                        case "Topping":
                            Topping topping = new Topping(inputParts[1], double.Parse(inputParts[2]));
                            Console.WriteLine($"{topping.Calories:F2}");
                            break;
                        case "Pizza":
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
                            return;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }

                input = Console.ReadLine();
            }
        }
    }
}