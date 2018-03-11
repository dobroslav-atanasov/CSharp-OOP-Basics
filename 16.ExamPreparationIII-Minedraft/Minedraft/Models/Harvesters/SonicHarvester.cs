using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;
    
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        set { this.sonicFactor = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.Append(base.ToString());
        return sb.ToString();
    }
}