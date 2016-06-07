using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_17___Office_Stuff
{
    class Order
    {
        public Order(string company, int amount, string product)
        {
            this.Company = company;
            this.Amount = amount;
            this.Product = product;
        }
        public string Company { get; set; }
        public int Amount { get; set; }
        public string Product { get; set; }
    }
}
