using System.Text;

public class PressureProvider : Provider
{
    private const double IncreaseEnergyOutput = 50;

    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput * (50 / 100.0);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Pressure Provider - {this.Id}")
            .Append(base.ToString());
        return sb.ToString();
    }
}