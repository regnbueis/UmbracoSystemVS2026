using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public static class TagRepository
    {

        public static List<Tag> GetTags()
        {
            List<Tag> Taglist = new List<Tag>();

            Taglist.Add(new Tag("Ryg"));
            Taglist.Add(new Tag("Lænd"));
            Taglist.Add(new Tag("Balder"));
            Taglist.Add(new Tag("Ben"));
            Taglist.Add(new Tag("Mave"));
            Taglist.Add(new Tag("Arme"));
            Taglist.Add(new Tag("Overkrop"));
            Taglist.Add(new Tag("Skulder"));

            return Taglist;
        }

    }
}
