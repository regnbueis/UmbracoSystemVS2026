using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public static class ExerciseRepository
    {
        public static Exercise Add(string title, string description, int timeSpent, string source, string tags)
        {
            Exercise result = null;

            if (!string.IsNullOrEmpty(title) &&
                !string.IsNullOrEmpty(description) &&
                timeSpent >= 0 &&
                !string.IsNullOrEmpty(source) &&
                !string.IsNullOrEmpty(tags))
            {
                result = new Exercise()
                {
                    Title = title,
                    Description = description,
                    TimeSpentInMinutes = timeSpent,
                    ImageSource = source,
                    Tagging = tags
                };
                Persist.exercises.Add(result);
            }
            else
                throw new ArgumentException("Not all arguments are valid");

            Persist.Save();
            return result;
        }

        public static void Edit(int id, string title, string description, int timeInMinutes, string source, string tags)
        {
            Exercise exercise = GetById(id);

            if (exercise != null)
            {
                if (string.IsNullOrEmpty(title) &&
                    string.IsNullOrEmpty(description) &&
                    timeInMinutes >= 0 &&
                    !string.IsNullOrEmpty(source) &&
                    !string.IsNullOrEmpty(tags))
                {
                    if (exercise.Title != title)
                        exercise.Title = title;
                    if (exercise.Description != description)
                        exercise.Description = description;
                    if (exercise.TimeSpentInMinutes != timeInMinutes)
                        exercise.TimeSpentInMinutes = timeInMinutes;
                    if (exercise.ImageSource != source)
                        exercise.ImageSource = source;
                    if (exercise.Tagging != tags)
                        exercise.Tagging = tags;
                }
                else
                    throw new ArgumentException("Not all arguments are valid");
            }
            else
                throw new ArgumentException("Exercise with ID " + id + " not found");

            Persist.Save();
        }

        public static Exercise GetById(int id)
        {
            Exercise result = null;

            foreach (Exercise e in Persist.exercises)
            {
                if (e.ExerciseId == id)
                    result = e;
            }
            return result;
        }

        public static List<Exercise> GetListByTag(string tag)
        {
            List<Exercise> results = new List<Exercise>();

            foreach (Exercise e in Persist.exercises)
            {
                if (e.Tagging.Contains(tag))
                    results.Add(e);
            }
            return results;
        }

        public static void Delete(int id)
        {
            Exercise content = GetById(id);
            if (content != null)
                Persist.exercises.Remove(content);
            else
                throw new ArgumentException("Exercise with ID " + id + " not found");
            Persist.Save();
        }

    }
}
