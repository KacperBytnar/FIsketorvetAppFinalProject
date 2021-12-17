using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.AllProducts
{
    public class EditProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; } = new Models.Product();

        private IProductRepository _service;
        public EditProductModel(IProductRepository service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Product = _service.GetProductWithID(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _service.EditProduct(Product);
                return RedirectToPage("AllProducts");
            }
            return Page();
        }
    }

}

