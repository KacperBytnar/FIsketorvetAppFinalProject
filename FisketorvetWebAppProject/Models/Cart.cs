using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Cart
    {
        public List<Product> _productsList;
        //public List<Product> _listOfDistinctProducts { get; set; }
        private double _totalPrice;

        public Cart()
        {
            _totalPrice = 0;
            _productsList = new List<Product>();
            //_listOfDistinctProducts = new List<Product>();
        }

        public List<Product> AllProduct()
        {
            return _productsList;
        }
        public void AddProduct(Product product)
        {
            _productsList.Add(product);
        }
        public void ClearCart()
        {
            _productsList.Clear();
        }
        //public void AddDistincProduct(Product product)
        //{
        //    if(_listOfDistinctProducts.Contains(product)==false)
        //        _listOfDistinctProducts.Add(product);
        //}

        public void RemoveProduct(Product product)
        {
            _productsList.Remove(product);
        }

        public void RemoveProductWithID(int ID)
        {
            foreach (var product in _productsList)
            {
                if (product.ID == ID)
                {
                    _productsList.Remove(product);
                    break;
                }
            }
        }

        public double CalculateTotalPrice()
        {
            _totalPrice = 0;
            foreach (var product in _productsList)
            {
                _totalPrice += product.Price;
            }
            return _totalPrice;
        }

        public int ProductQuantity(Product product)
        {
            int quantity = 0;
            foreach (var prod in _productsList)
            {
                if (prod.ID == product.ID)
                {
                    quantity++;
                }
            }
            return quantity;
        }

        //public bool CheckDistinctList(Product product)
        //{
        //    foreach (var prod in _listOfDistinctProducts)
        //    {
        //        if (!_listOfDistinctProducts.Contains(product)) return true;
        //    }
        //    return false;
        //}
        //    public void SetProductQuantity()
        //    {
        //        foreach (var product in _productsList)
        //        {
        //            if (!productsQuantity.ContainsKey(product))
        //                productsQuantity.Keys.Distinct().Count();   
        //            {
        //                productsQuantity.Add(product, 1);
        //            }
        //        }
        //        foreach (var product in _productsList)
        //        {
        //            if (productsQuantity.ContainsKey(product))
        //            {
        //                productsQuantity[product] = productsQuantity[product] + 1;
        //            }
        //        }
        //    }
    }
}
