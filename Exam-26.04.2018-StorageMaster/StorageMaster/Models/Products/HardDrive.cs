namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double DefaultWeight = 1;

        public HardDrive(double price)
            : base(price, DefaultWeight)
        {
        }
    }
}