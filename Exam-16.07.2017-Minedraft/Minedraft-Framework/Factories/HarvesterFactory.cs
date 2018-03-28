using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> parts)
    {
        string type = parts[0];
        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(parts[1], double.Parse(parts[2]), double.Parse(parts[3]), int.Parse(parts[4]));
            case "Hammer":
                return new HammerHarvester(parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
            default:
                return null;
        }
    }
}