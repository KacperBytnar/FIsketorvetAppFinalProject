using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.AllProducts
{
    public class DeleteProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; } = new Models.Product();
        private IProductRepository _service;
        public DeleteProductModel(IProductRepository service)
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {
            Product = _service.GetProductWithID(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            _service.DeleteProduct(Product);
            return RedirectToPage("AllProducts");
        }
    }
}
