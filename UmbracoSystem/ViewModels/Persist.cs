using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public static class Persist
    {
        public static List<Exercise> exercises;
        public static List<Event> events;
        public static List<AltWorkType> altWorkTypes;

        public static void Initialize()
        {
            exercises = new List<Exercise>();
            events = new List<Event>();
            altWorkTypes = new List<AltWorkType>();

            try
            {
                using StreamReader sr = new StreamReader("Resources/ContentPersistence.txt");
                {
                    int exerciseId = 0;
                    int eventId = 0;
                    int altWorkTypesId = 0;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] parts = line.Split("---");

                        if (int.TryParse(parts[1], out int id))
                        {
                            if (id >= 100 && id <= 299 && int.TryParse(parts[3], out int minutes))
                            {
                                Exercise exercise = new Exercise(parts[0], id, parts[2], minutes, parts[4], parts[5]);
                                exercises.Add(exercise);
                                if (exercise.ExerciseId > exerciseId)
                                    exerciseId = exercise.ExerciseId;
                            }
                            else if (id >= 400 && id <= 899 && DateTime.TryParse(parts[3], out DateTime date))
                            {
                                Event _event = new Event(parts[0], id, parts[2], date, parts[4]);
                                events.Add(_event);
                                if (_event.EventId > eventId)
                                    eventId = _event.EventId;
                            }
                            else if (id >= 300 && id <= 399)
                            {
                                AltWorkType altWorkType = new AltWorkType(parts[0], id, parts[2], parts[3]);
                                altWorkTypes.Add(altWorkType);
                                if (altWorkType.AltWorkTypeId > altWorkTypesId)
                                    altWorkTypesId = altWorkType.AltWorkTypeId;
                            }
                        }
                    }

                    Exercise.SetId(exerciseId);
                    Event.SetId(eventId);
                    AltWorkType.SetId(altWorkTypesId);
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public static void Save()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "ContentPersistence.txt");

            try
            {
                using StreamWriter sw = new StreamWriter(path);
                {
                    foreach (Exercise exercise in exercises)
                        sw.WriteLine($"{exercise.Title}---{exercise.ExerciseId}---{exercise.Description}---{exercise.TimeSpentInMinutes}---{exercise.ImageSource}---{exercise.Tagging}");
                    foreach (Event _event in events)
                        sw.WriteLine($"{_event.Title}---{_event.EventId}---{_event.Description}---{_event.Date}---{_event.ImageSource}");
                    foreach (AltWorkType altWorkType in altWorkTypes)
                        sw.WriteLine($"{altWorkType.Title}---{altWorkType.AltWorkTypeId}---{altWorkType.Description}---{altWorkType.ImageSource}");
                }
            }
            catch (IOException)
            {
               
            }
        }
    }


}