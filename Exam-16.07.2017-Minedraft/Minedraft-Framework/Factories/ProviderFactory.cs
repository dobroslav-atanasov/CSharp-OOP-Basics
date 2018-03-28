using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> parts)
    {
        string type = parts[0];
        switch (type)
        {
            case "Solar":
                return new SolarProvider(parts[1], double.Parse(parts[2]));
            case "Pressure":
                return new PressureProvider(parts[1], double.Parse(parts[2]));
            default:
                return null;
        }
    }
}