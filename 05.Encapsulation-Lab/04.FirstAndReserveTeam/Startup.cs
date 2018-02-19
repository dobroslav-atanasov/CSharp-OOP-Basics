using System;

public class Startup
{
    public static void Main()
    {
        Team team = new Team("SoftUni");

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            try
            {
                Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                team.AddPlayer(person);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(team);
    }
}