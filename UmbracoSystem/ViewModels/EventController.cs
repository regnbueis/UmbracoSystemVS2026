using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class EventController
    {
        public Event UpcomingEvent()
        {
            Event result = new Event();
            List<Event> events = EventRepository.UpcomingEvents();

            if (events.Count > 0)
            {
                foreach (Event e in events)
                {
                    if (result == null || (e.Date < result.Date))
                        result = e;
                }
            }
            else
            {
                result.Title = "Der er ingen nye events for nu. Vi glæder os til næste gang!";
                result.Date = DateTime.Now;
                result.Description = string.Empty;
                result.ImageSource = string.Empty;
            }
            return result;
        }
    }
}
