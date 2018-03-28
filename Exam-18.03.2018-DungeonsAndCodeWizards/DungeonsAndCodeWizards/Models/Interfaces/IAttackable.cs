namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using Characters;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}