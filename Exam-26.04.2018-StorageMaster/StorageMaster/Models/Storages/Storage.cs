namespace StorageMaster.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OutputMessages;
    using Products;
    using Vehicles;

    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];

            for (int i = 0; i < vehicles.ToList().Count; i++)
            {
                this.garage[i] = vehicles.ToList()[i];
            }


            this.products = new List<Product>();
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public double TotalProductsPrice => this.products.Sum(p => p.Price);

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(OutputMessage.InvalidGarageSlot);
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException(OutputMessage.NoVehiclesInThisGarage);
            }

            Vehicle vehicle = this.garage[garageSlot];
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!this.Garage.Any(g => g == null))
            {
                throw new InvalidOperationException(OutputMessage.NoRoomInGarage);
            }

            this.garage[garageSlot] = null;

            int freeSlot = 0;
            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    freeSlot = i;
                    break;
                }
            }

            deliveryLocation.garage[freeSlot] = vehicle;
            return freeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(OutputMessage.StorageIsFull);
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProducts = 0;
            foreach (Product product in vehicle.Trunk)
            {
                if (!vehicle.IsEmpty)
                {
                    if (!this.IsFull)
                    {
                        this.products.Add(product);
                        unloadedProducts++;
                    }
                }
            }

            return unloadedProducts;
        }
    }
}