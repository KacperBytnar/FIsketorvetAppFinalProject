using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public double totalAmount { get; set; }
        
    }
}
