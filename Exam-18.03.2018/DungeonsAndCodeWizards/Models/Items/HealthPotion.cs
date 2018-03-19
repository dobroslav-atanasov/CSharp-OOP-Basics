namespace DungeonsAndCodeWizards.Models.Items
{
    using Characters;

    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;
        private const double CharacterHealthIncrease = 20;

        public HealthPotion() 
            : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += CharacterHealthIncrease;
        }
    }
}