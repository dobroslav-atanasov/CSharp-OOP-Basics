namespace DungeonsAndCodeWizards.Factories
{
    using System;
    using Models.Items;

    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }
        }
    }
}