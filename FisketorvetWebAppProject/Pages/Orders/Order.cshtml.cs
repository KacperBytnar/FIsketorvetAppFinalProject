using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.Orders
{
    public class OrderModel : PageModel
    {
        public Order Order { get; set; }
        private IOrderRepository repo;
        public int ProductNO = 0;
        public bool IsPaid = false;
        public OrderModel(IOrderRepository repository)
        {
            repo = repository;
            Order = new Order();
        }

        public IActionResult OnGet(int id)
        {
            Order = repo.GetOrderWithID(id);
            return Page();
        }


        public void IncrementProductNO()
        {
            ProductNO++;
        }
    }
}
