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
    public class EventCreationModel : PageModel
    {

        [BindProperty]
        public Events Events { get; set; } = new Events();


        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }
        public List<Events> EventList { get; set; }

        private IEventRepository _repository;

        public EventCreationModel(IEventRepository repository)
        {
            _repository = repository;
            EventList = _repository.AllEvents();
        }

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(Criteria))
            {
                EventList = _repository.FilterEvents(Criteria);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _repository.AddEvent(Events);
                EventList = _repository.AllEvents();
            }

            return Redirect("/AllEvents/Events");
        }
    }
}
