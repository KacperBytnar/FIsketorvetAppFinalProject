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
    public class EditEventsModel : PageModel
    {
        [BindProperty]
        public Events Events { get; set; } = new Events();
        private IEventRepository _repository;

        public EditEventsModel(IEventRepository repository)
        {
            _repository = repository;
        }
        public void OnGet(int id)
        {
            Events = _repository.GetEvents(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _repository.EditEvent(Events);
                return RedirectToPage("/AllEvents/Events");
            }

            return Page();
        }
    }
}


