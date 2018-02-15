namespace HotelReservation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            PriceCalculator calculator = new PriceCalculator();
            calculator.ParseCommand(input);
            calculator.CalcualteTotalPrice();
        }
    }
}