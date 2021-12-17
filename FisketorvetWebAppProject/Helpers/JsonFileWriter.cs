using FisketorvetWebAppProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToUserAccounts(List<UserAccount> item, string JsonFilePath)
        {
            string output = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(JsonFilePath, output);
        }

        public static void WriteToProducts(List<Product> item, string JsonFilePath)
        {
            string output = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(JsonFilePath, output);
        }

        public static void WriteJson(List<Events> events, string filePath)
        {
            string output = JsonConvert.SerializeObject(events);

            File.WriteAllText(filePath, output);
        }

        public static void WriteToStores(List<Store> item, string JsonFilePath)
        {
            string output = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(JsonFilePath, output);
        }

        public static void WriteToOrders(List<Order> item, string JsonFilePath)
        {
            string output = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(JsonFilePath, output);
        }
    }
}
