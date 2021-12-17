using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Interfaces
{
    public interface IStoreRepository
    {
        public List<Store> AllStores(); //List
        void AddStore(Store store); //Add method
        void DeleteStore(Store store); //Delete method
        void UpdateStore(Store store); //Update method
        public int GetLastStoreID(); //Last item added to list
    }
}