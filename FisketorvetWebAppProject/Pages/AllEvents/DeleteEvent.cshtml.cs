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
    public class DeleteEventModel : PageModel
    {

        [BindProperty]
        public Events Events { get; set; } = new Events();

        private IEventRepository _repository;
        public DeleteEventModel(IEventRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(int id)
        {
            Events = _repository.GetEvents(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            _repository.DeleteEvent(Events);
            return RedirectToPage("/AllEvents/Events");
        }
    }
}
