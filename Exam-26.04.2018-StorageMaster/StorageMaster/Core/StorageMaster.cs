namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Factories;
    using Models.Products;
    using Models.Storages;
    using Models.Vehicles;
    using OutputMessages;

    public class StorageMaster
    {
        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;
        private List<Storage> storages;
        private List<Product> products;
        private Vehicle vehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storages = new List<Storage>();
            this.products = new List<Product>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            this.products.Add(product);
            return string.Format(OutputMessage.AddedProduct, type);
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);
            return string.Format(OutputMessage.RegisteredStorage, name);
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            this.vehicle = vehicle;

            return string.Format(OutputMessage.SelectedVehicle, vehicle.GetType().Name);
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            foreach (string name in productNames)
            {
                Product product = this.products.FirstOrDefault(p => p.GetType().Name == name);
                if (product == null)
                {
                    throw new InvalidOperationException(string.Format(OutputMessage.OutOfStock, name));
                }

                product = this.products.Last(p => p.GetType().Name == name);
                this.products.Remove(product);
                if (this.vehicle.IsFull)
                {
                    return string.Format(OutputMessage.LoadedProducts, this.vehicle.Trunk.Count, productNames.ToList().Count, this.vehicle.GetType().Name);
                }
                this.vehicle.LoadProduct(product);
            }
            
            return string.Format(OutputMessage.LoadedProducts, this.vehicle.Trunk.Count, productNames.ToList().Count, this.vehicle.GetType().Name);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storages.FirstOrDefault(s => s.Name == sourceName);
            if (sourceStorage == null)
            {
                throw new InvalidOperationException(OutputMessage.InvalidSourceStorage);
            }

            Storage destinationStorage = this.storages.FirstOrDefault(s => s.Name == destinationName);
            if (destinationStorage == null)
            {
                throw new InvalidOperationException(OutputMessage.InvalidDestinationStorage);
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int slot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return string.Format(OutputMessage.SendToStorage, vehicle.GetType().Name, destinationStorage.Name, slot);
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int unloadedProducts = storage.UnloadVehicle(garageSlot);

            return string.Format(OutputMessage.UnloadedProducts, unloadedProducts, vehicle.Trunk.Count, storage.Name);
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);

            double allProductsWeight = storage.Products.Sum(p => p.Weight);
            var sortedProducts = storage
                .Products
                .GroupBy(c => c.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .ToList();

            List<string> sortedProductsToString = new List<string>();
            foreach (var product in sortedProducts.OrderByDescending(p => p.Count).ThenBy(p => p.Name))
            {
                sortedProductsToString.Add($"{product.Name} ({product.Count})");
            }

            sb.AppendLine(string.Format(OutputMessage.StockFormat, allProductsWeight, storage.Capacity, string.Join(", ", sortedProductsToString)));

            List<string> vehicleInGarage = new List<string>();
            foreach (Vehicle vehicl in storage.Garage)
            {
                if (vehicl == null)
                {
                    vehicleInGarage.Add("empty");
                }
                else
                {
                    vehicleInGarage.Add(vehicl.GetType().Name);
                }
            }

            sb.AppendLine(string.Format(OutputMessage.Garage, string.Join("|", vehicleInGarage)));
            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Storage storage in this.storages.OrderByDescending(s => s.TotalProductsPrice))
            {
                sb.AppendLine(string.Format(OutputMessage.StorageName, storage.Name))
                    .AppendLine(string.Format(OutputMessage.StorageWorth, $"{storage.TotalProductsPrice:F2}"));
            }

            return sb.ToString().Trim();
        }
    }
}