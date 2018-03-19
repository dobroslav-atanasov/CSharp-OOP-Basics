namespace DungeonsAndCodeWizards.Factories
{
    using System;
    using Models.Characters;
    using Models.Enums;

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            Faction currentFaction;
            if (!Enum.TryParse(faction, out currentFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, currentFaction);
                case "Cleric":
                    return new Cleric(name, currentFaction);
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
        }
    }
}