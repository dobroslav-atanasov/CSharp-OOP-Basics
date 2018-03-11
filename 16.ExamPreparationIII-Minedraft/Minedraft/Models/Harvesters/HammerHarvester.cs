using System.Text;

public class HammerHarvester : Harvester
{
    private const int IncreaseOreIoutput = 200;
    private const int IncreaseEnergyRequirment = 100;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput = oreOutput + (oreOutput * IncreaseOreIoutput / 100);
        this.EnergyRequirement = energyRequirement + (energyRequirement * IncreaseEnergyRequirment / 100);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.Append(base.ToString());
        return sb.ToString();
    }
}