using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_17___Office_Stuff
{
    class OfficeStuff
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            List<Order> orders = new List<Order>();
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string company = input.Split('-').ToArray()[0].Trim();
                int amount = int.Parse(input.Split('-').ToArray()[1].Trim());
                string product = input.Split('-').ToArray()[2].Trim();
                orders.Add(new Order(company.Substring(1), amount, product.Substring(0, product.Length - 1)));
            }
            var groupedOrders = from order in orders
                                group order by new { order.Company, order.Product } into gr
                                select new { gr.Key.Company, gr.Key.Product, Amount = gr.Sum(am => am.Amount) };
            groupedOrders.OrderBy(gr => gr.Company);
            foreach (var group in groupedOrders)
            {
                Console.WriteLine(group.Company+": "+group.Product+"-"+group.Amount);
            }
        }
    }
}
