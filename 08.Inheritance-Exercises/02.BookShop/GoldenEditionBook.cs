public class GoldenEditionBook : Book
{
    private const int Percentage = 30;

    public GoldenEditionBook(string title, string author, decimal price) 
        : base(title, author, price)
    {
    }

    public override decimal Price
    {
        get { return this.CalculatePrice(); }
    }

    private decimal CalculatePrice()
    {
        decimal price = (base.Price * Percentage / 100) + base.Price;
        return price;
    }
}