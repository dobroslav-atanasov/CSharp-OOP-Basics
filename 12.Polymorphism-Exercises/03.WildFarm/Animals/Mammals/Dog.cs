public class Dog : Mammal
{
    private const double DogFoodPiece = 0.40;

    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return "Woof!";
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
        this.Weight += food.Quantity * DogFoodPiece;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}