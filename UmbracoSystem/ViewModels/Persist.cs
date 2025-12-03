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
                using StreamReader sr = new StreamReader("ContentPersistence.txt");
                {


                    int exerciseId = 0;
                    int eventId = 0;
                    int altWorkTypesId = 0;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split("---");

                        if (int.Parse(parts[1]) >= 100 && int.Parse(parts[1]) <= 299)
                        {
                            Exercise exercise = new Exercise(parts[0], int.Parse(parts[1]), parts[2], int.Parse(parts[3]), parts[4], parts[5]);

                            exercises.Add(exercise);

                            if (exercise.ExerciseId > exerciseId)
                                exerciseId = exercise.ExerciseId;
                        }
                        else if (int.Parse(parts[1]) >= 400 && int.Parse(parts[1]) <= 899)
                        {
                            Event _event = new Event(parts[0], int.Parse(parts[1]), parts[2], DateTime.Parse(parts[3]), parts[4]);

                            events.Add(_event);

                            if (_event.EventId > eventId)
                                eventId = _event.EventId;
                        }
                        else if (int.Parse(parts[1]) >= 300 && int.Parse(parts[1]) <= 399)
                        {
                            AltWorkType altWorkType = new AltWorkType(parts[0], int.Parse(parts[1]), parts[2], parts[3]);

                            altWorkTypes.Add(altWorkType);

                            if (altWorkType.AltWorkTypeId > altWorkTypesId)
                                altWorkTypesId = altWorkType.AltWorkTypeId;
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
            try
            {
                using StreamWriter sw = new StreamWriter("ContentPersistence.txt");
                {
                    foreach (Exercise exercise in exercises)
                        sw.WriteLine($"{exercise.Title}---{exercise.ExerciseId}---{exercise.Description}---{exercise.TimeSpentInMinutes}---{exercise.ImageSource}---{exercise.Tagging}");
                    foreach (Event _event in events)
                        sw.WriteLine($"{_event.Title}---{_event.EventId}---{_event.Description}---{_event.Date}---{_event.ImageSource}");
                    foreach (AltWorkType altWorkType in altWorkTypes)
                        sw.WriteLine($"{altWorkType.Title}---{altWorkType.AltWorkTypeId}---{altWorkType.Description}---{altWorkType.ImageSource}");
                }
            }
            catch
            {
                throw new Exception("Save not succesful");
            }
        }
    }
}
