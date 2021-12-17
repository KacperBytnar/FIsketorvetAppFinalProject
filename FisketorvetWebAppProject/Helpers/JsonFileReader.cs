using FisketorvetWebAppProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Helpers
{
    public class JsonFileReader
    {
        //public static List<UserAccount> ReadJson(string jsonFilePath)
        //{
        //    string output = File.ReadAllText(jsonFilePath);
        //    return JsonConvert.DeserializeObject<List<UserAccount>>(output);
        //}

        // Read user account JSON file then return list of UserAccount 
        public static List<UserAccount> ReadUserAccounts(string jsonFilePath)
        {
            string output = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<UserAccount>>(output);
        }

        // Read product JSON file then return list of products
        public static List<Product> ReadProducts(string jsonFilePath)
        {
            string output = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Product>>(output);
        }

        public static List<Events> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Events>>(jsonString);
        }

        public static List<Store> ReadStores(string jsonFilePath)
        {
            string output = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Store>>(output);
        }
        public static List<Order> ReadOrders (string jsonFilePath)
        {
            string output = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Order>>(output);
        }

    }
}
