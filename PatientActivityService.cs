using dotnet_soap_example.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_soap_example
{
    public class PatientActivityService : IPatientActivityService
    {
        public List<PatientActivity> getHistoryActivities()
        {
            List<PatientActivity> activities = new List<PatientActivity>();

            string fileInput = System.IO.File.ReadAllText("activity.txt");

            StringReader stringReader = new StringReader(fileInput);
            string aLine;
            while (true)
            {
                aLine = stringReader.ReadLine();
                if (aLine != null)
                {
                    string[] words = aLine.Split(new Char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    DateTime startTime = DateTime.Parse(words[0]);
                    DateTime endTime = DateTime.Parse(words[1]);
                    string activityInput = words[2];

                    double time_difference = (endTime - startTime).TotalSeconds / 3600;
                    Boolean isNormal = true;
                    double duration = Math.Round(time_difference, 2);

                    DateTime activityDate = startTime;
                    if (startTime.Day != endTime.Day)
                    {
                        string date = endTime.ToString("yyyy-MM-dd");
                        string midnight = date + "T" + "00:00:00";
                        DateTime midnightDate = DateTime.Parse(midnight);
                        time_difference = (midnightDate - startTime).TotalSeconds / 3600;
                        duration = Math.Round(time_difference, 2);
                    }
                     
                    if (time_difference > 12 && (activityInput.Equals("Sleeping") || activityInput.Equals("Leaving")))
                    {
                        isNormal = false;
                    }
                    if (time_difference > 1 && (activityInput.Equals("Toileting") || activityInput.Equals("Showering") || 
                        activityInput.Equals("Grooming")))
                    {
                        isNormal = false;
                    }

                    activities.Add(new PatientActivity(10, activityDate, activityInput, duration, isNormal));
                }
                else
                {
                    break;
                }
            }

            return activities;
        }

        public PatientActivity TestPatientActivity(PatientActivity patientActivity)
        {
            return patientActivity;
        }
    }
}
