using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.Pages.User
{
    public class AccountLoginModel : PageModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        private IUserAccountRepository catalog;
        public AccountLoginModel(IUserAccountRepository service)
        {
            catalog = service;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return CheckLogin();
            }
            else return Page();
        }

        public string LoginMessage = "";
        private IActionResult CheckLogin()
        {
            var login = Request.Form["username"];
            var password = Request.Form["password"];
                
            if (catalog.UserCheck(login, password) == true)
            {
                UserAccount User = catalog.GetUserWithLogin(login);
                if (User.isAdmin == true)
                {
                    // an admin
                    HttpContext.Session.SetString("admin", User.Name);
                    return Redirect("/AllEvents/Events");
                }
                //normal user with a login account
                else
                {
                    HttpContext.Session.SetString("normal", User.Name);
                    return Redirect("/AllEvents/Events");
                }
            }
            else
            {
                LoginMessage = "Invalid data!";
                return Page();
            }
        }
    }
}
