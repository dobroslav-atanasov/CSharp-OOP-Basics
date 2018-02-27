using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corp, List<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corp)
    {
        this.Repairs = repairs;
    }

    public List<IRepair> Repairs { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Repairs:");
        foreach (IRepair repair in this.Repairs)
        {
            sb.AppendLine($"  {repair}");
        }
        return sb.ToString().Trim();
    }
}