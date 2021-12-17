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
    public class ShopsModel : PageModel
    {
        public List<Models.Store> Stores;
        public List<UserAccount> Users = new List<UserAccount>();
        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }
        private IStoreRepository Catalog;
        private IUserAccountRepository Repository;
        public ShopsModel(IStoreRepository service, IUserAccountRepository repository)
        {
            Catalog = service;
            Repository = repository;
        }
        public IActionResult OnGet()
        {
            //if (string.IsNullOrEmpty(Criteria))
            // {
            Stores = Catalog.AllStores();
            Users = Repository.AllUsers();
            //}
            //else
            //{
            //    EventList = _repository.FilterEvents(Criteria);

            //}
            return Page();
        }
    }
}
