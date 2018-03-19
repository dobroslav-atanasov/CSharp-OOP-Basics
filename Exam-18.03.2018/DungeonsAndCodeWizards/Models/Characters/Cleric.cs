namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using Bags;
    using Enums;
    using Interfaces;

    public class Cleric : Character, IHealable
    {
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;

        public Cleric(string name, Faction faction) 
            : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            base.CheckIsAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}