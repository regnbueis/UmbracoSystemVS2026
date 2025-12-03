using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class Event
    {
        private static int idCount = 400;

        public string Title { get; set; }
        public int EventId { get; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImageSource { get; set; }

        public Event()
        {
            EventId = idCount++;
        }

        public Event(string title, int id, string description, DateTime date, string imageSource)
        {
            Title = title;
            EventId = idCount++;
            Description = description;
            Date = date;
            ImageSource = imageSource;
        }

        public Event(string title, string description, DateTime date, string imageSource) :
            this(title, idCount++, description, date, imageSource)
        {
        }
        public static void SetId(int id)
        {
            idCount = id;
        }
    }
}
