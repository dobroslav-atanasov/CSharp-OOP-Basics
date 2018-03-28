using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> history;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation()},
            {"Earth", new Nation()},
            {"Fire", new Nation()},
            {"Water", new Nation()},
        };
        this.history = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[1];
        switch (type)
        {
            case "Air":
                AirBender airBender = new AirBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                this.nations["Air"].Benders.Add(airBender);
                break;
            case "Earth":
                EarthBender earthBender = new EarthBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                this.nations["Earth"].Benders.Add(earthBender);
                break;
            case "Fire":
                FireBender fireBender = new FireBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                this.nations["Fire"].Benders.Add(fireBender);
                break;
            case "Water":
                WaterBender waterBender = new WaterBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                this.nations["Water"].Benders.Add(waterBender);
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[1];
        switch (type)
        {
            case "Air":
                AirMonument airMonument = new AirMonument(monumentArgs[2], int.Parse(monumentArgs[3]));
                this.nations["Air"].Monuments.Add(airMonument);
                break;
            case "Earth":
                EarthMonument earthMonument = new EarthMonument(monumentArgs[2], int.Parse(monumentArgs[3]));
                this.nations["Earth"].Monuments.Add(earthMonument);
                break;
            case "Fire":
                FireMonument fireMonument = new FireMonument(monumentArgs[2], int.Parse(monumentArgs[3]));
                this.nations["Fire"].Monuments.Add(fireMonument);
                break;
            case "Water":
                WaterMonument waterMonument = new WaterMonument(monumentArgs[2], int.Parse(monumentArgs[3]));
                this.nations["Water"].Monuments.Add(waterMonument);
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");
        if (this.nations[nationsType].Benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (Bender bender in this.nations[nationsType].Benders)
            {
                sb.AppendLine($"###{bender}");
            }
        }
        if (this.nations[nationsType].Monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (Monument monument in this.nations[nationsType].Monuments)
            {
                sb.AppendLine($"###{monument}");
            }
        }
        return sb.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        int index = this.history.Count;
        this.history.Add($"War {index + 1} issued by {nationsType}");

        foreach (KeyValuePair<string, Nation> nation in this.nations.OrderByDescending(n => n.Value.TotalPower).Skip(1))
        {
            nation.Value.Benders.Clear();
            nation.Value.Monuments.Clear();
        }
    }

    public string GetWarsRecord()
    {
        StringBuilder sb =new StringBuilder();
        foreach (string war in this.history)
        {
            sb.AppendLine(war);
        }
        return sb.ToString().Trim();
    }
}