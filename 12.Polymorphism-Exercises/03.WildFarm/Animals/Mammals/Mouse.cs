public class Mouse : Mammal
{
    private const double MouseFoodPiece = 0.10;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return "Squeak";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
        {
            Validator.GetValidation(this.GetType().Name, food.GetType().Name);
            base.FoodEaten = 0;
            return;
        }
        base.FoodEaten = food.Quantity;
        this.Weight += food.Quantity * MouseFoodPiece;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}