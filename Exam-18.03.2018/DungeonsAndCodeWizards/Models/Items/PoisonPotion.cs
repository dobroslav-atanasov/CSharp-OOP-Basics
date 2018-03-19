namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using Characters;

    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;
        private const double CharacterHealthDecrease = 20;

        public PoisonPotion() 
            : base(PoisonPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= CharacterHealthDecrease;
            character.Health = Math.Max(0, character.Health);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}