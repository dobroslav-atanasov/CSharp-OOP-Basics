using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string title, string author, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            string[] fullName = value.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (fullName.Length > 1)
            {
                string lastName = fullName[1];
                if (Char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            
            this.author = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .Append($"Price: {this.Price:F2}");

        return sb.ToString();
    }
}