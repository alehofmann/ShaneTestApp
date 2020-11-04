using ShaneSampleApp.Models;
using System.Collections.Generic;

namespace ShaneSampleApp.DataLayer
{
    public interface IPatientRepo
    {
        IList<PatientModel> GetAll();
        void MarkDeleted(string patientId);
        void Delete(string patientId);
        PatientModel GetById(string id);
        void AddOrUpdate(PatientModel patient);
    }
}
