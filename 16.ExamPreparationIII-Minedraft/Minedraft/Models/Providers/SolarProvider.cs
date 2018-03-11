using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Solar Provider - {this.Id}");
        sb.Append(base.ToString());
        return sb.ToString();
    }
}