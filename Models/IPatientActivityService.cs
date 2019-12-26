using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace dotnet_soap_example.Models
{
    [ServiceContract]
    interface IPatientActivityService
    {
        [OperationContract]
        PatientActivity TestPatientActivity(PatientActivity patientActivity);
        [OperationContract]
        List<PatientActivity> getHistoryActivities();
    }
}
