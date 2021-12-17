using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Customer : UserAccount
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public Cart CustomerCart { get; set; }

        public Customer(string name, string login, string password, bool _isAdmin) :base(name, login, password, _isAdmin)
        {
            CustomerCart = new Cart();
        }
        public Customer()
        {
            CustomerCart = new Cart();
        }
    }
}
