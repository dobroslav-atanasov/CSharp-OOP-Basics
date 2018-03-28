namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using Characters;

    public interface IHealable
    {
        void Heal(Character character);
    }
}