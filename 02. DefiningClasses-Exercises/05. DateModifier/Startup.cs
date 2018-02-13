namespace DateModifier
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            DateTime firstDate = DateTime.ParseExact(firstInput, "yyyy MM dd", null);
            DateTime secondDate = DateTime.ParseExact(secondInput, "yyyy MM dd", null);

            DataModifier dateModifier = new DataModifier();
            Console.WriteLine(dateModifier.CalculateDays(firstDate, secondDate));
        }
    }
}