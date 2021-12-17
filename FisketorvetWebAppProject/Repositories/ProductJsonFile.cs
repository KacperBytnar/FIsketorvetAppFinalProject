using FisketorvetWebAppProject.Helpers;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Repositories
{
    public class ProductJsonFile : IProductRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; } //Property
        private string jsonFilePath //Property for retrieving the JSON file path
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Products.json"); }
        }


        public List<Product> Products; //List of Products

        public ProductJsonFile(IWebHostEnvironment webHostEnvironment) //Constructor 
        {
            WebHostEnvironment = webHostEnvironment;
            Products = JsonFileReader.ReadProducts(jsonFilePath); //Reference to JSON file
        }

        public List<Product> AllProducts() //Method for returning all elements contained within the list
        {
            return Products; //return the List (All elements)
        }

        public void EditProduct(Product product)
        {
            if (product != null)
            {
                foreach (var prod in Products)
                {
                    if (prod.ID == product.ID)
                    {
                        prod.Name = product.Name;
                        prod.Shop = product.Shop;
                        prod.Price = product.Price;
                        prod.InStock = product.InStock;
                        prod.Image = product.Image;

                    }
                }
            }
            JsonFileWriter.WriteToProducts(Products, jsonFilePath); //
        }

        public void AddProduct(Product product) //The method that allows the user to add a specifieed product to the list
        {
            Products.Add(product); //take in parameter and add to the list
            JsonFileWriter.WriteToProducts(Products, jsonFilePath); //
        }

        public void DeleteProduct(Product product) //Remove specified product from list
        {
            if(product != null)
            {
                foreach (var x in Products) //loops through list of type product
                {
                    if (x.ID == product.ID) //Condition: if item in list of products matches passed parameter 
                    {
                        Products.Remove(x); //Result: remove the product from the list
                        break; //
                    }
                }
            }
            JsonFileWriter.WriteToProducts(Products, jsonFilePath); //
        }

        public void UpdateProduct(Product product) //Update method for product
        {
            DeleteProduct(product); //Delete product passeed in parameter from the list
            AddProduct(product); //Add a product passed through parameter from the list
        }

        public int GetLastProductID() //Allows the user to get the last ID passed through Sign Up
        {
            return Products.Last().ID; //Returns last item added to the list
        }
        public Product GetProductWithID(int id)
        {
            foreach (var product in Products)
            {
                if (product.ID == id)
                    return product;
            }
            return new Product();
        }

        public List<Product> FilterProductsByStore(string store)
        {
            List<Product> FilteredProducts = new List<Product>();
            foreach(var product in Products)
            {
                if (product.Shop == store)
                {
                    FilteredProducts.Add(product);
                }
            }
            return FilteredProducts;
        }
    }
}