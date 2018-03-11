using System;

public class Validator
{
    public static void CheckHarvesterOreOutput(string property, double value)
    {
        if (value < 0)
        {
            throw new ArgumentException($"Harvester is not registered, because of it's {property}");
        }
    }

    public static void CheckHarvesterEnergyRequirement(string property, double value)
    {
        if (value < 0 || value > 20000)
        {
            throw new ArgumentException($"Harvester is not registered, because of it's {property}");
        }
    }

    public static void CheckProviderEnergyRequirment(string property, double value)
    {
        if (value < 0 || value > 10000)
        {
            throw new ArgumentException($"Provider is not registered, because of it's {property}");
        }
    }
}