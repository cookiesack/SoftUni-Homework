namespace PriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class ProductsInPriceRange
    {
        static void Main(string[] args)
        {
            OrderedBag<Product> collection = new OrderedBag<Product>();
            int lowestPrice, highestPrice;
            for (int i = 0; i < 500000; i++)
            {
                collection.Add(new Product(i.ToString(), i + 1));
            }
            for (int i = 0; i < 1; i++)
            {
                lowestPrice = i + 10;
                highestPrice = i + 100;
                var results = collection.Range(new Product("a", lowestPrice), true, new Product("b", highestPrice), true).ToList();
                for (int j = 0; j < Math.Min(20, results.Count); j++)
                {
                    Console.WriteLine(results[j].Name);
                }
            }
        }
    }
}
