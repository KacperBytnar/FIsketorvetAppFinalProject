using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> AllOrders(); //Method for returning all elements contained within the list
        public void AddOrder(Order order); //The method that allows the user to add a specifieed order to the list
        public int GetLastOrderID(); // Returns last order ID
        public Order GetOrderWithID(int id); // Get order with ID 

    }
}
