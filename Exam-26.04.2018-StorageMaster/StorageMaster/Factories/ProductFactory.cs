namespace StorageMaster.Factories
{
    using System;
    using Models.Products;
    using OutputMessages;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            switch (type)
            {
                case "Gpu":
                    return new Gpu(price);
                case "HardDrive":
                    return new HardDrive(price);
                case "Ram":
                    return new Ram(price);
                case "SolidStateDrive":
                    return new SolidStateDrive(price);
                default:
                    throw new InvalidOperationException(OutputMessage.InvalidProduct);
            }
        }
    }
}