public class Owl : Bird
{
    private const double OwlFoodPiece = 0.25;

    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string MakeSound()
    {
        return $"Hoot Hoot";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            Validator.GetValidation(this.GetType().Name, food.GetType().Name);
            base.FoodEaten = 0;
            return;
        }
        base.FoodEaten = food.Quantity;
        this.Weight += food.Quantity * OwlFoodPiece;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {base.FoodEaten}]";
    }
}