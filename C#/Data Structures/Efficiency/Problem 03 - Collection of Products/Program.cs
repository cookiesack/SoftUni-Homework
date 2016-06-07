using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03___Collection_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            var emag = new ProductCollection();
            emag.Add(new Product(1, "Speak T100", "Freeman", 19.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(2, "Storm X450", "E-BODA", 199.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(3, "I9301", "Samsung", 354.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(4, "A4 Your Life", "Allview", 87.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(5, "I9301", "Samsung", 354.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(6, "Speak T100", "Freeman", 20.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(9, "E1270", "Samsung", 38.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(8, "105", "Nokia", 34.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(7, "105", "Maybekia", 35.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(10, "105", "Yeskia", 34.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Add(new Product(5, "I8200", "Samsung", 198.99M));
            Console.WriteLine(emag);
            Console.WriteLine();
            emag.Remove(4);
            Console.WriteLine(emag);
            Console.WriteLine();

            foreach (var product in emag.FindInPriceRange(0M, 198.99M))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (var product in emag.FindByTitle("105", 35.99M))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (var product in emag.FindByTitle("105", 35.99M))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (var product in emag.FindByTitle("105", 34.99M, 35.98M))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (var product in emag.FindBySupplier("Samsung"))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (var product in emag.FindBySupplier("Samsung", 0M, 198.99M))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }
    }
}
