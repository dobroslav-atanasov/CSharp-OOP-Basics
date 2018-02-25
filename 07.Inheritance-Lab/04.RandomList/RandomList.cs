using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        this.random = new Random();
    }

    public string RandomString()
    {
        return "";
    }
}