using System;

public class Startup
{
    public static void Main()
    {
        string[] firstInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] secondInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            Student student = new Student(firstInput[0], firstInput[1], firstInput[2]);
            Worker worker = new Worker(secondInput[0], secondInput[1], double.Parse(secondInput[2]), double.Parse(secondInput[3]));

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}