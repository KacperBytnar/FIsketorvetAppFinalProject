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
    public class StoreJsonFile : IStoreRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; } //Property
        private string jsonFilePath //Property for retrieving the JSON file path
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Shops.json"); }
        }


        public List<Store> Stores; //List of Stores

        public StoreJsonFile(IWebHostEnvironment webHostEnvironment) //Constructor 
        {
            WebHostEnvironment = webHostEnvironment;
            Stores = JsonFileReader.ReadStores(jsonFilePath); //Reference to JSON file
        }

        public List<Store> AllStores()//Method for returning all elements contained within the list
        {
            return Stores; //return the List (All elements)
        }
        public void AddStore(Store store) //The method that allows the user to add a specifieed store to the list
        {
            Stores.Add(store); //take in parameter and add to the list
            JsonFileWriter.WriteToStores(Stores, jsonFilePath); //Writes on JSONFile
        }

        public void DeleteStore(Store store) //Remove specified store from list
        {
            foreach (var x in Stores) //loops through list of type Store
            {
                if (x == store) //Condition: if item in the list of stores matches passed parameter 
                {
                    Stores.Remove(store); //Result: remove the store from the list
                }
            }
        }

        public void UpdateStore(Store store) //Update method for store
        {
            DeleteStore(store); //Delete store passeed in parameter from the list
            AddStore(store); //Add a store passed through parameter from the list
        }

        public int GetLastStoreID() //Allows the user to get the last ID passed through list
        {
            return Stores.Last().StoreID; //Returns last item added to the list
        }
    }
}