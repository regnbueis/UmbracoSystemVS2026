using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class AltWorkTypeRepository
    {

        public static AltWorkType Add(string title, string description, string source)
        {

            AltWorkType result = null;

            if (!string.IsNullOrEmpty(title) &&
                !string.IsNullOrEmpty(description) &&
                !string.IsNullOrEmpty(source))
            {
                result = new AltWorkType()
                {
                    Title = title,
                    Description = description,
                    ImageSource = source
                };
                Persist.altWorkTypes.Add(result);
                
            }
            else
                throw new ArgumentException("Not all arguments are valid");

            Persist.Save();
            return result;
        }

        public static void Edit(int id, string title, string description, string source)
        {
            AltWorkType altWorkType = GetById(id);

            if (altWorkType != null)
            {
                if (string.IsNullOrEmpty(title) &&
                    string.IsNullOrEmpty(description) &&
                    !string.IsNullOrEmpty(source))
                {
                    if (altWorkType.Title != title)
                        altWorkType.Title = title;
                    if (altWorkType.Description != description)
                        altWorkType.Description = description;
                    if (altWorkType.ImageSource != source)
                        altWorkType.ImageSource = source;
                }
                else
                    throw new ArgumentException("Not all arguments are valid");
            }
            else
                throw new ArgumentException("Content with ID " + id + " not found");
            Persist.Save();
        }

        public static void Delete(int id)
        {
            AltWorkType a = GetById(id);
            if (a != null)
                Persist.altWorkTypes.Remove(a);
            else
                throw new ArgumentException("Content with ID " + id + " not found");
            Persist.Save();
        }

        public static AltWorkType GetById(int id)
        {
            AltWorkType result = null;

            foreach (AltWorkType a in Persist.altWorkTypes)
            {
                if (a.AltWorkTypeId == id)
                    result = a;
            }
            return result;
        }

        public static List<AltWorkType> GetAll()
        {
            return Persist.altWorkTypes;
        }
    }
}
