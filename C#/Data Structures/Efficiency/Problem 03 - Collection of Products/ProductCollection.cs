using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem_03___Collection_of_Products
{
    class ProductCollection
    {
        private OrderedDictionary<int, Product> products;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice;
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice;
        private OrderedMultiDictionary<decimal, Product> productsByPrice;

        public ProductCollection()
        {
            products = new OrderedDictionary<int, Product>();
            productsByTitle = new Dictionary<string, SortedSet<Product>>();
            productsByTitleAndPrice = new Dictionary<string, SortedSet<Product>>();
            productsBySupplierAndPrice = new Dictionary<string, SortedSet<Product>>();
            productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public void Add(Product product)
        {
            if (products.ContainsKey(product.Id))
            {
                this.Remove(product.Id);
            }

            products.Add(product.Id, product);

            // Title
            if (!productsByTitle.ContainsKey(product.Title))
            {
                productsByTitle.Add(product.Title, new SortedSet<Product>());
            }

            productsByTitle[product.Title].Add(product);

            // TitleAndPrice
            if (!productsByTitleAndPrice.ContainsKey(product.Title))
            {
                productsByTitleAndPrice.Add(product.Title, new SortedSet<Product>(new PriceComparer()));
            }

            productsByTitleAndPrice[product.Title].Add(product);

            // SupplierAndPrice
            if (!productsBySupplierAndPrice.ContainsKey(product.Supplier))
            {
                productsBySupplierAndPrice.Add(product.Supplier, new SortedSet<Product>(new PriceComparer()));
            }

            productsBySupplierAndPrice[product.Supplier].Add(product);

            // Price
            productsByPrice.Add(product.Price, product);


        }

        public bool Remove(int id)
        {
            if (!products.ContainsKey(id))
                return false;

            Product product = products[id];
            products.Remove(id);
            productsByTitle.Remove(product.Title);
            productsByTitleAndPrice.Remove(product.Title);
            productsBySupplierAndPrice.Remove(product.Supplier);
            productsByPrice.Remove(product.Price, product);
            return true;
        }

        public IEnumerable<Product> FindInPriceRange(decimal start, decimal end)
        {
            return productsByPrice.Range(start, true, end, true).Values.OrderBy(x=>x.Id);
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return productsByTitle[title].OrderBy(x => x.Id);
        }
        public IEnumerable<Product> FindByTitle(string title, decimal price)
        {
            return productsByTitleAndPrice[title].OrderBy(x => x.Id);
        }
        public IEnumerable<Product> FindByTitle(string title, decimal startPrice, decimal endPrice)
        {
            return productsByTitleAndPrice[title].Where(x => x.Price >= startPrice && x.Price <= endPrice).OrderBy(x => x.Id);
        }
        public IEnumerable<Product> FindBySupplier(string supplier)
        {
            return productsBySupplierAndPrice[supplier].OrderBy(x => x.Id);
        }
        public IEnumerable<Product> FindBySupplier(string supplier, decimal startPrice, decimal endPrice)
        {
            return productsBySupplierAndPrice[supplier].Where(x => x.Price >= startPrice && x.Price <= endPrice).OrderBy(x => x.Id);
        }

        public override string ToString()
        {
            return string.Join("\n", this.products.Values);
        }
    }

    class PriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
