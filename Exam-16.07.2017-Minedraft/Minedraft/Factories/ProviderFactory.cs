using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        switch (type)
        {
            case "Pressure":
                return new PressureProvider(arguments[1], double.Parse(arguments[2]));
            case "Solar":
                return new SolarProvider(arguments[1], double.Parse(arguments[2]));
        }
        return null;
    }
}