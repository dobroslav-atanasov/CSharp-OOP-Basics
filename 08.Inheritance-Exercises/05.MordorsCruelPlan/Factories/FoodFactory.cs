public class FoodFactory
{
    public static Food GetFood(string foodName)
    {
        switch (foodName.ToLower())
        {
            case "apple":
                return new Apple(1);
            case "cram":
                return new Cram(2);
            case "honeycake":
                return new HoneyCake(5);
            case "lembas":
                return new Lembas(3);
            case "melon":
                return new Melon(1);
            case "mushrooms":
                return new Mushrooms(-10);
            default:
                return new OtherFood(-1);
        }
    }
}