using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class LogController
    {
        public Dictionary<int, int> LoadScoreboard()
        {
            Dictionary<int, int> scoreboard = new Dictionary<int, int>();
            Dictionary<int, int> sortedScoreboard = new Dictionary<int, int>();
            try
            {
                foreach (Log log in LogRepository.AllLogs)
                {
                    if (log.LogTypeId == 1)
                    {
                        if (scoreboard.ContainsKey(log.EmployeeId))
                            scoreboard[log.EmployeeId]++;
                        else
                            scoreboard.Add(log.EmployeeId, 1);
                    }
                }

                while (sortedScoreboard.Count < scoreboard.Count)
                {
                    var b = new KeyValuePair<int, int>();

                    foreach (KeyValuePair<int, int> a in scoreboard)
                    {
                        if (!sortedScoreboard.ContainsKey(a.Key))
                        {
                            if (a.Value > b.Value)
                                b = a;
                        }
                    }
                    sortedScoreboard.Add(b.Key, b.Value);
                }
            }
            catch
            {

            }

            return sortedScoreboard;
        }

        public bool CheckFavoriteStatus(int employeeId, int exerciseID)
        {
            //tjekke foreach i loggen for den seneste registrering af LogInstanceID for EmployeeID og exerciseID
            ////med LogTypeID 2 eller 3

            Log log = new Log();
            bool result = false;

            try
            {
                foreach (Log l in LogRepository.AllLogs)
                {

                    if (l.EmployeeId == employeeId && l.ExerciseId == exerciseID && (l.LogTypeId == 2 || l.LogTypeId == 3))
                    {
                        if (log == null || log.LogSetTime < l.LogSetTime)
                            log = l;
                    }
                }
            }
            catch
            {

            }

            if (log != null && log.LogTypeId == 2)
            {
                result = true;
            }
            // hvis result = true, så er øvelsen allerede favorited af den pågældende medarbejder
            return result;
        }
    }
}
