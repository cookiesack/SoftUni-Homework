using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03___Collection_of_Products
{
    class Product : IComparable
    {
        private int id;
        private string title;
        private string supplier;
        private decimal price;

        public Product(int id, string title, string supplier, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Supplier
        {
            get { return this.supplier; }
            set { this.supplier = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int CompareTo(object obj)
        {
            var other = obj as Product;
            return this.id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, Supplier: {2}, {3}", Id, Title, Supplier, Price);
        }
    }
}
