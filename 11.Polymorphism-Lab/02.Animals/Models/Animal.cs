public abstract class Animal
{
    protected Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public string Name { get; set; }

    public string FavouriteFood { get; set; }

    public virtual string ExplainMyself()
    {
        return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
    }
}