using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.User
{
    public class ShoppingCartModel : PageModel
    {
        public Cart ShoppingCart { get; }
        public Models.Product product { get; set; }
        //public IEnumerable<Models.Product> distinctProductsList;
        private IProductRepository repo;
        public List<Models.Product> ListOfProducts { get; set; }


        public ShoppingCartModel(Cart chart, IProductRepository repository)
        {
            ShoppingCart = chart;
            repo = repository;
            ListOfProducts = new List<Models.Product>();
        }
        public IActionResult OnGet(int id)
        {
            if (id>0&&id<100)
            {
                Models.Product product = repo.GetProductWithID(id);
                ShoppingCart.AddProduct(product);
                //ShoppingCart.AddDistincProduct(product);
            }
            ListOfProducts = ShoppingCart.AllProduct();
            //distinctProductsList = ListOfProducts.Distinct();
            return Page();
        }
        public IActionResult OnPostDelete(int ID)
        {
            ShoppingCart.RemoveProductWithID(ID);
            ListOfProducts = ShoppingCart.AllProduct();
            return Page();
        }

    //    public List<Models.Product> ListOfDistinctProducts()
    //    {
    //        foreach (var prod in ListOfProducts)
    //        {
    //            if (!_listOfDistinctProducts.Contains(prod))
    //            {
    //                _listOfDistinctProducts.Add(prod);
    //            }
    //        }
    //        return _listOfDistinctProducts;
    //    }
    }
}
