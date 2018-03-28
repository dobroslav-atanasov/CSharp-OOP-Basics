using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
            case "Sonic":
                return new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4]));
        }
        return null;
    }
}