using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class EmployeeController
    {
        public List<Exercise> PerformedExercises(int employeeId)
        {
            List<Log> loggedExercises = new List<Log>();
            List<Exercise> result = new List<Exercise>();

            foreach (Log log in LogRepository.AllLogs)
            {
                if (log.EmployeeId == employeeId && log.LogTypeId == 1)
                    loggedExercises.Add(log);
            }

            foreach (Log log in loggedExercises)
            {
                //får lige lidt hjælp af LINQ her, fordi vi ellers skulle have været ude
                //i 40 foreach loops.
                //result.Any tjekker hele resultslisten igennem
                //(exercise => erklærer exercise som en lokal variabel, der kun eksisterer
                //inden for if-statementets condition (scope) - ubekendte i en ligning, basically
                if (!result.Any(exercise => exercise.ExerciseId == log.ExerciseId))
                {
                    result.Add(ExerciseRepository.GetById(log.ExerciseId));
                }
            }
            return result;
        }
    }
}
