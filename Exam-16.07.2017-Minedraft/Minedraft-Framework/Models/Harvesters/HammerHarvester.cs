using System.Text;

public class HammerHarvester : Harvester
{
    private const double IncreaseOreOutput = 200;
    private const double IncreaseEnergyRequirement = 100;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += this.OreOutput * (200 / 100.0);
        this.EnergyRequirement += this.EnergyRequirement * (100 / 100.0);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}")
            .Append(base.ToString());
        return sb.ToString();
    }
}