public class Cat : Feline
{
    private const double CatFoodPiece = 0.30;

    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string MakeSound()
    {
        return "Meow";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
        {
            Validator.GetValidation(this.GetType().Name, food.GetType().Name);
            base.FoodEaten = 0;
            return;
        }
        base.FoodEaten = food.Quantity;
        this.Weight += food.Quantity * CatFoodPiece;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}