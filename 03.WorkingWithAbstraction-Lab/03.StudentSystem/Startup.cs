namespace StudentSystem
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            string input = Console.ReadLine();
            while (input != "Exit")
            {
                studentSystem.ParseCommand(input);
                input = Console.ReadLine();
            }
        }
    }
}