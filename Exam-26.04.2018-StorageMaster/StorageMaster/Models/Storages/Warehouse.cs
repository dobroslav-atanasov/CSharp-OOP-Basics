namespace StorageMaster.Models.Storages
{
    using System.Collections.Generic;
    using Vehicles;

    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;

        public Warehouse(string name) 
            : base(name, DefaultCapacity, DefaultGarageSlots, new List<Vehicle>(){new Semi(), new Semi(), new Semi()})
        {
        }
    }
}