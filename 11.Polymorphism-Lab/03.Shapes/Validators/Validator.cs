using System;

public class Validator
{
    public static void CheckDimension(double value, string dimension)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{dimension} cannot be zero or negative number!");
        }
    }
}