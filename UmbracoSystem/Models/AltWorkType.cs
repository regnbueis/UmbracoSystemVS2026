using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class AltWorkType
    {
        private static int idCount = 300;

        public string Title { get; set; }
        public int AltWorkTypeId { get; }
        public string Description { get; set; }
        public string ImageSource { get; set; }

        public AltWorkType(string title, int id, string description, string imageSource)
        {
            Title = title;
            AltWorkTypeId = idCount++;
            Description = description;
            ImageSource = imageSource;
        }

        public AltWorkType(string title, string description, string imageSource) :
            this(title, idCount++, description, imageSource)
        {
        }

        public AltWorkType()
        {
            AltWorkTypeId = idCount++;
        }

        public static void SetId(int id)
        {
            idCount = id;
        }
    }
}
