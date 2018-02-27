using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    List<ISoldier> Privates { get; }
}