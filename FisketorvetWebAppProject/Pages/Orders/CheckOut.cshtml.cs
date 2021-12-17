using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FisketorvetWebAppProject.Pages.Orders
{
    public class CheckOutModel : PageModel
    {
        public Cart cart;
        private IOrderRepository repo;
        [BindProperty]
        public Customer customer { get; set; }
        [BindProperty]
        public Order order { get; set; }
        public CheckOutModel(IOrderRepository repository, Cart cartService)
        {
            repo = repository;
            cart = cartService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                // Creating new order part

                //Incrementing oder ID
                order.ID = repo.GetLastOrderID();
                order.IncrementID();

                order.Customer = customer;
                order.Customer.CustomerCart._productsList = cart.AllProduct();
                order.TotalPrice = cart.CalculateTotalPrice();
                order.Customer.Name = HttpContext.Session.GetString("normal");
                order.DateTime = DateTime.Now;
                order.Status = State.Awaiting_Payment.ToString();
                repo.AddOrder(order);
                cart.ClearCart();
                return RedirectToPage("Order", new { id = order.ID });
            }
        }
    }
}
