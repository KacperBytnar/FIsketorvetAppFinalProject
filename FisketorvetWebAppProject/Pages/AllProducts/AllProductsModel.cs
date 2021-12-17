using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages
{
    public class AllProductsModel : PageModel
    {
        public List<Models.Product> Products;
        public List<Store> Stores;
        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }
        private IProductRepository Catalog;
        private IStoreRepository Store;
        public AllProductsModel(IProductRepository service, IStoreRepository shop)
        {
            Catalog = service;
            Store = shop;
        }
        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Criteria)||Criteria=="All Stores")
            {
                Products = Catalog.AllProducts();
                Stores = Store.AllStores();
            }
            else
            {
                Products = Catalog.FilterProductsByStore(Criteria);
                Stores = Store.AllStores();
            }
            return Page();
        }
    }
}
