using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<ISoldier> privates) 
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<ISoldier> Privates { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Privates:");
        foreach (ISoldier @private in this.Privates)
        {
            sb.AppendLine($"  {@private}");
        }
        return sb.ToString().Trim();
    }
}