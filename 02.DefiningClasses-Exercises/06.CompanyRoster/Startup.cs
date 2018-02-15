namespace CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                decimal salary = decimal.Parse(inputParts[1]);
                string position = inputParts[2];
                string department = inputParts[3];
                Employee employee = new Employee(name, salary, position, department);

                if (inputParts.Length == 5)
                {
                    int age;
                    if (int.TryParse(inputParts[4], out age))
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        employee.Email = inputParts[4];
                    }
                }
                else if (inputParts.Length == 6)
                {
                    string email = inputParts[4];
                    int age = int.Parse(inputParts[5]);
                    employee.Email = email;
                    employee.Age = age;
                }
                employees.Add(employee);
            }

            var query = employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(d => d.Salary),
                    Employees = e.OrderByDescending(d => d.Salary)
                })
                .OrderByDescending(e => e.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {query.Department}");
            foreach (Employee employee in query.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}