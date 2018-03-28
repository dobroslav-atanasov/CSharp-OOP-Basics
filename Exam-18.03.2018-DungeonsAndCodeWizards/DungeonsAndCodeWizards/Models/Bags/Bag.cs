namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Items;

    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private readonly List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        private int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        protected int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException($"Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.Items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.Items.First(i => i.GetType().Name == name);
            return item;
        }
    }
}