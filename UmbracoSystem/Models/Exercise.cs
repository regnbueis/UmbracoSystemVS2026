using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class Exercise
    {
        private static int idCount = 100;

        public string Title { get; set; }
        public int ExerciseId { get; }
        public string Description { get; set; }
        public int TimeSpentInMinutes { get; set; }
        public string ImageSource { get; set; }
        // public bool Favorite { get; set; } //den her markering hører egentlig til employee-klassen, ikke til øvelsen
        public string Tagging { get; set; }
        //public Tag Tags { get; set; } - fravalg af enums som tags, da det er nemmere for os at håndtere string separation, især ved flere tags

        public Exercise()
        {
            ExerciseId = idCount++;
        }

        public Exercise(string title, int id, string description, int timeSpentInMinutes, string imageSource, string tags)
        {
            Title = title;
            ExerciseId = id;
            Description = description;
            TimeSpentInMinutes = timeSpentInMinutes;
            ImageSource = imageSource;
            Tagging = tags;
        }

        public Exercise(string title, string description, int timeSpentInMinutes, string imageSource, string tags) :
          this(title, idCount++, description, timeSpentInMinutes, imageSource, tags)
        {
        }

        public static void SetId(int id)
        {
            idCount = id;
        }
    }
}
