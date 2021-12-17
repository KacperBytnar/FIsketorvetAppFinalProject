using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages
{
    public class RegisterUserAccountModel : PageModel
    {
        [BindProperty]
        public UserAccount User { get; set; } = new UserAccount();
        public string registerMessage { get; set; }

        public List<UserAccount> users = new List<UserAccount>();
        private IUserAccountRepository catalog;
        public RegisterUserAccountModel(IUserAccountRepository catalogService)
        {
            catalog = catalogService;
        }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public void OnGet() //Method allows user to receive data on their display
        {
        }
        public IActionResult OnPost()
        {
            if (User.Password != ConfirmPassword)
            {
                registerMessage = "Passwords are different!";
                return Page();
            }
            else if (User.Password == null)
            {
                registerMessage = "Passwords can't be empty!";
                return Page();
            }
            else
            {
                // getting last user ID from database and incrementing it so there will be no duplicates
                User.Id = catalog.GetLastUserID();
                User.IncrementID();
                // adding new user into database and redirecting to the login page
                catalog.AddUser(User);
                return Redirect("/User/AccountLogin");
            }
        }
    }
}
