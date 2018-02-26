using System;
using System.Text;

public class Worker : Human
{
    private const int WorkingDays = 5;

    private double weekSalary;
    private double hoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
    }

    public double HoursPerDay
    {
        get { return this.hoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.hoursPerDay = value;
        }
    }

    public double WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    private double CalculateSalaryPerHour()
    {
        double salaryPerHour = (this.WeekSalary / WorkingDays) / this.HoursPerDay;
        return salaryPerHour;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:F2}")
            .AppendLine($"Hours per day: {this.HoursPerDay:F2}")
            .Append($"Salary per hour: {this.CalculateSalaryPerHour():F2}");
        return sb.ToString();
    }
}