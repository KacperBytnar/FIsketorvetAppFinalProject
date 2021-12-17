using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class UserAccount
    {
        // ID field with properties
        public int Id { get; set; }


        public string Name { get; set; }
        public string Login { get; set; }
        //[Required,MinLength(4),MaxLength(16)]
        public string Password { get; set; }
        //[Required, MinLength(4), MaxLength(16)]
        public bool isAdmin { get; set; }

        public UserAccount(string name, string login, string password, bool _isAdmin)
        {
            Name = name;
            Login = login;
            Password = password;
            isAdmin = _isAdmin;
        }

        public UserAccount()
        {
        }

        public void IncrementID()
        {
            Id++;
        }
    }
}
