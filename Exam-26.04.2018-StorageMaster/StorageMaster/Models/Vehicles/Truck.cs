namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DefaultCapacity = 5;

        public Truck() 
            : base(DefaultCapacity)
        {
        }
    }
}