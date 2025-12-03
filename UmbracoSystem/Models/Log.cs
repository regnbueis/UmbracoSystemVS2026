using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class Log
    {
        private static int idCount = 0;
        public int LogInstanceId { get; }
        public DateTime LogSetTime { get; set; }
        public int EmployeeId { get; set; }
        public int ExerciseId { get; set; }
        public int LogTypeId { get; set; } //1 = Performed, 2 = Favorited, 3 = Unfavorited

        public Log()
        {
            LogInstanceId = idCount++;
        }

        public Log(int logId, DateTime logSetTime, int employeeId, int exerciseId, int logTypeId)
        {
            LogInstanceId = logId;
            LogSetTime = logSetTime;
            EmployeeId = employeeId;
            ExerciseId = exerciseId;
            LogTypeId = logTypeId;
        }

        public Log(DateTime logSetTime, int employeeId, int exerciseId, int logTypeId) :
            this(idCount++, logSetTime, employeeId, exerciseId, logTypeId)
        { }

        public static void SetId(int id)
        {
            idCount = id;
        }
    }
}
