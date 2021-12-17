using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Interfaces
{
    public interface IEventRepository
    {
        List<Events> AllEvents();
        void AddEvent(Events events);
        void DeleteEvent(Events events);
        List<Events> FilterEvents(string criteria);
        void EditEvent(Events events);
        Events GetEvents(int id);

    }
}
