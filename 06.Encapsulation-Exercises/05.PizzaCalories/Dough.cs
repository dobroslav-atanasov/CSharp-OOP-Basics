using System;

public class Dough
{
    private string flour;
    private string bakingTechnique;
    private double weight;
    private double calories;

    public Dough(string flour, string bakingTechnique, double weight)
    {
        this.Flour = flour;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double Calories
    {
        get { return this.CalculateCalories(); }
    }

    public double Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    public string Flour
    {
        get { return this.flour; }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flour = value;
        }
    }

    private double CalculateCalories()
    {
        double totalCalories = this.weight * 2;
        switch (this.flour.ToLower())
        {
            case "white":
                totalCalories *= 1.5;
                break;
            case "wholegrain":
                totalCalories *= 1;
                break;
        }
        switch (this.bakingTechnique.ToLower())
        {
            case "crispy":
                totalCalories *= 0.9;
                break;
            case "chewy":
                totalCalories *= 1.1;
                break;
            case "homemade":
                totalCalories *= 1;
                break;
        }
        return totalCalories;
    }
}