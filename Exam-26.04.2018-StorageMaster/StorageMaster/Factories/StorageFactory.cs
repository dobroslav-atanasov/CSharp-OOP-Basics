namespace StorageMaster.Factories
{
    using System;
    using Models.Storages;
    using OutputMessages;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException(OutputMessage.InvalidStorage);
            }
        }
    }
}