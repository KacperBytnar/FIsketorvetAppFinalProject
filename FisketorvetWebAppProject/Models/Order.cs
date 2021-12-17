using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Order
    {
        public int ID { get; set; }
        public List<Product> ProductList { get; set; }
        public string Status { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public Payment Payment{ get; set; }

        public Order()
        {
        }

        public void IncrementID()
        {
            ID++;
        }
    }
}
