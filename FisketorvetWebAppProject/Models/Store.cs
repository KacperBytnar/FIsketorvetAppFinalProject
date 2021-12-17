using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Store
    {
        //Instance Fields/Variables
        private int _StoreID;
        private string _name;
        private string _location;
        private string _description;
        private string _phoneNumber;
        private string _category;
        public string Image { get; set; }

        public Store() //Constructor
        {
        }

        //Propertis
        public int StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}