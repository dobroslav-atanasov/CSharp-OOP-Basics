using System.Text;

public abstract class Harvester : Machine
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            Validator.CheckHarvesterEnergyRequirement(nameof(this.EnergyRequirement), value);
            this.energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            Validator.CheckHarvesterOreOutput(nameof(this.OreOutput), value);
            this.oreOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString();
    }
}