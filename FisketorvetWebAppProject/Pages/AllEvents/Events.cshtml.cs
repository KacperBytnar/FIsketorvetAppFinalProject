using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FisketorvetWebAppProject.AllEvents
{
    public class EventsModel : PageModel
    {
        public List<Events> EventList { get; set; } = new List<Events>();

        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        private IEventRepository _repository;

        public EventsModel(IEventRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Criteria))
            {
                EventList = _repository.AllEvents();
            }
            else
            {
                EventList = _repository.FilterEvents(Criteria);
            }
            return Page();
        }

    }
}
