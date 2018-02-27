using System.Collections.Generic;

public interface IEngineer : ISpecialisedSoldier
{
    List<IRepair> Repairs { get; }
}