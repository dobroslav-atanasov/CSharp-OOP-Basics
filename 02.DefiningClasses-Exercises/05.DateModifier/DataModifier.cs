namespace DateModifier
{
    using System;

    public class DataModifier
    {
        public double CalculateDays(DateTime firstDate, DateTime secondDate)
        {
            return Math.Abs((firstDate - secondDate).TotalDays);
        }
    }
}