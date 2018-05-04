namespace StorageMaster.Models.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OutputMessages;
    using Products;

    public abstract class Vehicle
    {
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(OutputMessage.VehichleIsFull);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(OutputMessage.TruckIsEmpty);
            }

            Product product = this.trunk.Last();
            return product;
        }
    }
}