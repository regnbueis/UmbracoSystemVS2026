using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class Tag
    {
        public string TagName { get; }

        public Tag (string tagName)
        {
            TagName = tagName;
        }
    }
}
