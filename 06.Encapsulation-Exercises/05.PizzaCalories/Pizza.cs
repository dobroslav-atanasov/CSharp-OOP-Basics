using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dought;
    private double calories;

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public double Calories
    {
        get { return this.CalculateCalories(); }
    }

    public Dough Dought
    {
        get { return this.dought; }
        set { this.dought = value; }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        private set
        {
            if (value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    private double CalculateCalories()
    {
        double totalCalories = this.dought.Calories;
        foreach (Topping topping in this.toppings)
        {
            totalCalories += topping.Calories;
        }
        return totalCalories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:F2} Calories.";
    }
}