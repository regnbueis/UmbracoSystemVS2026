using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public static class EventRepository
    {
        public static Event Add(string title, string description, DateTime date, string source)
        {
            Event result = null;

            if (!string.IsNullOrEmpty(title) &&
                !string.IsNullOrEmpty(description) &&
                date != DateTime.MinValue &&
                !string.IsNullOrEmpty(source))
            {
                result = new Event()
                {
                    Title = title,
                    Description = description,
                    Date = date,
                    ImageSource = source
                };
                Persist.events.Add(result);
            }
            else
                throw new ArgumentException("Not all arguments are valid");

            Persist.Save();
            return result;
        }

        public static void Edit(int id, string title, string description, DateTime date, string source)
        {
            Event _event = GetById(id);

            if (_event != null)
            {
                if (string.IsNullOrEmpty(title) &&
                    string.IsNullOrEmpty(description) &&
                    date != DateTime.MinValue &&
                    !string.IsNullOrEmpty(source))
                {
                    if (_event.Title != title)
                        _event.Title = title;
                    if (_event.Description != description)
                        _event.Description = description;
                    if (_event.Date != date)
                        _event.Date = date;
                    if (_event.ImageSource != source)
                        _event.ImageSource = source;
                }
                else
                    throw new ArgumentException("Not all arguments are valid");
            }
            else
                throw new ArgumentException("Event with ID " + id + " not found");
            Persist.Save();
        }

        public static void Delete(int id)
        {
            Event _event = GetById(id);
            if (_event != null)
                Persist.events.Remove(_event);
            else
                throw new ArgumentException("Event with ID " + id + " not found");
            Persist.Save();
        }

        public static Event GetById(int id)
        {
            Event result = null;

            foreach (Event e in Persist.events)
            {
                if (e.EventId == id)
                    result = e;
            }
            return result;
        }

        public static List<Event> UpcomingEvents()
        {
            List<Event> nextEvents = new List<Event>();

            try
            {
                foreach (Event e in Persist.events)
                {
                    if (e.Date > DateTime.Now)
                        nextEvents.Add(e);
                }
            }
            catch { }

            return nextEvents;
        }

    }
}
