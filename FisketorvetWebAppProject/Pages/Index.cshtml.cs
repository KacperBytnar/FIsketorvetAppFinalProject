using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using FisketorvetWebAppProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Events> EventList { get; set; } = new List<Events>();

        private IEventRepository _repository;

        public IndexModel(IEventRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            EventList = _repository.AllEvents();
            return Page();
        }
    }
}