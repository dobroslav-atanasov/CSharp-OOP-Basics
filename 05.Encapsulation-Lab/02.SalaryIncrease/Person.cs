public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;
    
    public Person(string firstName, string lastName, int age, double salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public double Salary
    {
        get { return this.salary; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public string LastName
    {
        get { return this.lastName; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public void IncreaseSalary(double bonus)
    {
        if (this.Age <= 30)
        {
            this.salary += this.Salary * bonus / 200;
        }
        else
        {
            this.salary += this.Salary * bonus / 100;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}