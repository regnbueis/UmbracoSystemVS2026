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
                if (!result.Any(exercise => exercise.ExerciseId == log.ExerciseId))
                {
                    result.Add(ExerciseRepository.GetById(log.ExerciseId));
                }
            }
            return result;
        }
    }
}
