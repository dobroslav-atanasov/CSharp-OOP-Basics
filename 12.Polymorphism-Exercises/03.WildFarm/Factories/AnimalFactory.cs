public class AnimalFactory
{
    public static Animal GetAnimal(string[] animalParts)
    {
        string animalType = animalParts[0];
        switch (animalType)
        {
            case "Hen":
                return new Hen(animalParts[1], double.Parse(animalParts[2]), double.Parse(animalParts[3]));
            case "Owl":
                return new Owl(animalParts[1], double.Parse(animalParts[2]), double.Parse(animalParts[3]));
            case "Mouse":
                return new Mouse(animalParts[1], double.Parse(animalParts[2]), animalParts[3]);
            case "Dog":
                return new Dog(animalParts[1], double.Parse(animalParts[2]), animalParts[3]);
            case "Cat":
                return new Cat(animalParts[1], double.Parse(animalParts[2]), animalParts[3], animalParts[4]);
            case "Tiger":
                return new Tiger(animalParts[1], double.Parse(animalParts[2]), animalParts[3], animalParts[4]);
            default:
                return null;
        }
    }
}