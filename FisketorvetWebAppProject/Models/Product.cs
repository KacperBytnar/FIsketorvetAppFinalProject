using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Models
{
    public class Product
    {
        private int _ID; // product ID
        private string _shop; // what shop the product belongs to
        private double _price; // price of the product
        private bool _inStock; //shows whether product is available or not
        [Required, MaxLength(32)]
        private string _name; // the products names
        public string _image; // product's image route

        //private IUserAccountRepository productDetails;  //JSON file for product details
        public Product(string name, string image, double price) //Constructor
        {
            _name = name;
            _image = image;
            _price = price;
        }

        public Product()
        {
        }

        //Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Shop
        {
            get { return _shop; }
            set { _shop = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public bool InStock
        {
            get { return _inStock; }
            set { _inStock = value; }
        }
        [Required, MaxLength(32)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public void IncrementID()
        {
            ID++;
        }
        public void ShowProductDetails(string ID)
        {
            
        }
    }
}