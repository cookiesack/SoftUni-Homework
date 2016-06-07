using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceRange
{
    class Product : IComparable
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            Product other = obj as Product;
            if (this.Price > other.Price) return 1;
            else if (this.Price == other.Price) return 0;
            else return -1;
        }
    }
}
