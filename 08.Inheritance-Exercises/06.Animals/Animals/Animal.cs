using System;
using System.Text;

public abstract class Animal : IProduceSound
{
    private string name;
    private int age;
    private string gender;

    protected Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "Animal sound!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .Append($"{this.ProduceSound()}");
        return sb.ToString();
    }
}