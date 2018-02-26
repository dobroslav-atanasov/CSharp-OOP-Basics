using System;
using System.Text;

public class Human
{
    private const int FirstNameMinLength = 4;
    private const int LastNameMinLength = 3;

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < LastNameMinLength)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length < FirstNameMinLength)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .Append($"Last Name: {this.LastName}");
        return sb.ToString();
    }
}