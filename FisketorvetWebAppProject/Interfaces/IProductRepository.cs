using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> AllProducts(); //List
        void AddProduct(Product product); //Add method
        void DeleteProduct(Product product); //Delete method
        public Product GetProductWithID(int id); // Get product with ID
        void UpdateProduct(Product product); //Update method
        public int GetLastProductID(); //Last item added to list
        public void EditProduct(Product product); // Edit a Product;
        public List<Product> FilterProductsByStore(string store); // Filter products by store
    }
}