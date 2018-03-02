public class FoodFactory
{
    public static Food GetFood(string[] foodParts)
    {
        string foodType = foodParts[0];
        switch (foodType)
        {
            case "Fruit":
                return new Fruit(int.Parse(foodParts[1]));
            case "Meat":
                return new Meat(int.Parse(foodParts[1]));
            case "Seeds":
                return new Seeds(int.Parse(foodParts[1]));
            case "Vegetable":
                return new Vegetable(int.Parse(foodParts[1]));
            default:
                return null;
        }
    }
}