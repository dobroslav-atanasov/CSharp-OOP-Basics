namespace HotelReservation
{
    using System;
    using Enums;

    public class PriceCalculator
    {
        private double pricePerDay;
        private int numberOfDays;
        private Season season;
        private DiscountType discountType;

        public void ParseCommand(string input)
        {
            string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.pricePerDay = double.Parse(inputParts[0]);
            this.numberOfDays = Int32.Parse(inputParts[1]);
            this.season = Enum.Parse<Season>(inputParts[2]);
            this.discountType = DiscountType.None;

            if (inputParts.Length == 4)
            {
                this.discountType = Enum.Parse<DiscountType>(inputParts[3]);
            }
        }

        public void CalcualteTotalPrice()
        {
            double totalPrice = this.pricePerDay * this.numberOfDays * (int) this.season;
            double discount = totalPrice * ((int) this.discountType / 100.0);
            double price = totalPrice - discount;
            Console.WriteLine($"{price:F2}");
        }
    }
}