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
    public class OrderJsonRepository : IOrderRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; } //Property
        private string jsonFilePath //Property for retrieving the JSON file path
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Orders.json"); }
        }


        public List<Order> Orders { get; set; } = new List<Order>(); //List of Products

        public OrderJsonRepository(IWebHostEnvironment webHostEnvironment) //Constructor 
        {
            WebHostEnvironment = webHostEnvironment;
            Orders = JsonFileReader.ReadOrders(jsonFilePath); //Reference to JSON file
        }

        public List<Order> AllOrders() //Method for returning all elements contained within the list
        {
            return Orders; //return the List (All elements)
        }

        public void AddOrder(Order order) //The method that allows the user to add a specifieed product to the list
        {
            Orders.Add(order); //take in parameter and add to the list
            JsonFileWriter.WriteToOrders(Orders, jsonFilePath); //
        }

        public int GetLastOrderID() //Allows the user to get the last ID passed through Sign Up
        {
            if (Orders.Count >= 1)
                return Orders.Last().ID; //Returns last item added to the list
            else
                return 0;
        }

        public Order GetOrderWithID(int id)
        {
            foreach (var order in Orders)
            {
                if (order.ID == id)
                    return order;
            }
            return new Order();
        }
    }
}
