using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    List<IMission> Missions { get; }
}