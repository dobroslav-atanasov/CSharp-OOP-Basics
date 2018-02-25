namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public List<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }
                this.money = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.Money -= product.Cost;
                this.Products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}