using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace dotnet_soap_example.Models
{
    public class PatientActivity
    {
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public DateTime ActivityDate { get; set; }
        [DataMember]
        public string Activity { get; set; }
        [DataMember]
        public double Duration { get; set; }
        [DataMember]
        public Boolean IsNormal { get; set; }

        public PatientActivity()
        {

        }
        public PatientActivity(int patientId, DateTime activityDate, string activity, double duration, Boolean isNormal)
        {
            PatientId = patientId;
            Activity = activity;
            Duration = duration;
            IsNormal = isNormal;
            ActivityDate = activityDate;
        }
    }
}
