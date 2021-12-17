using FisketorvetWebAppProject.Helpers;
using FisketorvetWebAppProject.Interfaces;
using FisketorvetWebAppProject.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Repositories
{
    public class JsonEventsRepository : IEventRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string jsonFilePath
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "EventJson.json"); }
        }
        public JsonEventsRepository(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            EventList = JsonFileReader.ReadJson(jsonFilePath);
        }

        public List<Events> EventList;

        public List<Events> AllEvents()
        {
            return EventList;
        }

        public void AddEvent(Events events)
        {

            EventList.Add(events);
            JsonFileWriter.WriteJson(EventList, jsonFilePath);
        }
        public void DeleteEvent(Events events)
        {

            foreach (var evt in EventList)
            {
                if (evt.Id == events.Id)
                {
                    EventList.Remove(evt);
                    break;
                }
            }
            JsonFileWriter.WriteJson(EventList, jsonFilePath);
        }

        public List<Events> FilterEvents(string criteria)
        {

            List<Events> FilteredEvents = new List<Events>();
            foreach (var events in EventList)
            {
                if (events.Title.Contains(criteria))
                {
                    FilteredEvents.Add(events);
                }
            }
            return FilteredEvents;
        }

        public void EditEvent(Events events)
        {
            if (events != null)
            {
                foreach (var evt in EventList)
                {
                    if (evt.Id == events.Id)
                    {
                        evt.Title = events.Title;
                        evt.Description = events.Description;
                        evt.Image = events.Image;
                    }
                }
            }
            JsonFileWriter.WriteJson(EventList, jsonFilePath);
        }

        public Events GetEvents(int id)
        {
            foreach (var evt in EventList)
            {
                if (evt.Id == id)
                    return evt;
            }
            return new Events();
        }
    }
}
