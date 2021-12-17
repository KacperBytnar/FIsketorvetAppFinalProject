using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.Product
{
    public class CreateProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        // path for the Images folder
        private string ImagePath
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "images/ProductImages"); }
        }

        private IProductRepository catalog;
        public IWebHostEnvironment WebHostEnvironment { get; } //Property
        private IHostingEnvironment _environment;
        public CreateProductModel(IProductRepository service, IHostingEnvironment environment, IWebHostEnvironment webHostEnvironment)
        {
            catalog = service;
            _environment = environment;
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Product.ID = catalog.GetLastProductID();
                Product.IncrementID();

            //C: \Users\Acer\Desktop\FisketorvetWebAppProject\FisketorvetWebAppProject\wwwroot\images\ProductImages\desk.PNG
             // path for the filename
             var file = Path.Combine(_environment.ContentRootPath, ImagePath, Upload.FileName);

                // we upload the file
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    Upload.CopyTo(fileStream);
                }

                // before creating the user, we assign the file name as the Image property
                Product.Image = Upload.FileName;

                // Add a new product
                catalog.AddProduct(Product);
                return RedirectToPage("AllProducts");
            }
            else return Page();
        }


        public void OnGet()
        {
        }
    }
}
