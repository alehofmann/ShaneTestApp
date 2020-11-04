using ShaneSampleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace ShaneSampleApp.DataLayer

{
    public class PatientRepo :IPatientRepo
    {
        private string _fileName = "PatientsDb.xml";        
        private string _xmlFile;
        private Helper.Encryption _crypto;
        public PatientRepo()
        {            
            var appRoot = HttpContext.Current.Server.MapPath("~/");
            _xmlFile = Path.Combine(appRoot, _fileName);
            _crypto = new Helper.Encryption();
        }


        public PatientModel GetById(string id)
        {
            XDocument patientsDoc = XDocument.Load(_xmlFile);

            return (from record in patientsDoc.Elements("Patients").Elements("Patient")
                    where 
                        record != null && 
                        record.Element("IsDeleted") != null && 
                        record.Element("IsDeleted").Value == "0" &&
                        record.Element("Id").Value==id
                    select HydratePatient(record)).FirstOrDefault();
        }

        public IList<PatientModel> GetAll()
        {
            XDocument patientsDoc = XDocument.Load(_xmlFile);

            return (from record in patientsDoc.Elements("Patients").Elements("Patient")
                        where record != null && record.Element("IsDeleted")!=null && record.Element("IsDeleted").Value == "0"
                        select HydratePatient(record)).ToList();

        }
        private PatientModel HydratePatient(XElement record)
        {            
            return new PatientModel
            {
                Id = record.TryGetElementValue("Id"),
                CreatedDate = record.TryGetElementValue("CreatedDate"),
                Email = _crypto.Decrypt(record.TryGetElementValue("Email")),
                FirstName = _crypto.Decrypt(record.TryGetElementValue("FirstName")),
                LastName = _crypto.Decrypt(record.TryGetElementValue("LastName")),
                IsDeleted = record.TryGetElementValue("IsDeleted"),
                LastUpdatedDate = record.TryGetElementValue("LastUpdatedDate"),
                Gender = _crypto.Decrypt(record.TryGetElementValue("Gender")),
                Notes = record.TryGetElementValue("Notes"),
                PhoneNumber = _crypto.Decrypt(record.TryGetElementValue("PhoneNumber")),
            };         
                
        }
        public void AddOrUpdate(PatientModel patient)
        {
            if(!string.IsNullOrEmpty(patient.Id))
            {
                Delete(patient.Id);
                patient.LastUpdatedDate = DateTime.UtcNow.ToString();                
            }
            else
            {
                patient.CreatedDate = DateTime.UtcNow.ToString();                
            }
            AddRecord(patient);

        }
        private void AddRecord(PatientModel patient)
        {
            XDocument patientsDoc = XDocument.Load(_xmlFile);

            patientsDoc.Element("Patients")
                .Add(new XElement("Patient",
                new XElement("Id", Guid.NewGuid().ToString()),
                new XElement("CreatedDate", patient.CreatedDate),
                new XElement("Email", _crypto.Encrypt(patient.Email)),
                new XElement("FirstName", _crypto.Encrypt(patient.FirstName)),
                new XElement("LastName", _crypto.Encrypt(patient.LastName)),
                new XElement("LastUpdatedDate", patient.LastUpdatedDate),
                new XElement("Gender", _crypto.Encrypt(patient.Gender)),
                new XElement("Notes", patient.Notes),
                new XElement("PhoneNumber", _crypto.Encrypt(patient.PhoneNumber)),
                new XElement("IsDeleted", "0")));

            patientsDoc.Save(_xmlFile);
        }
        public void Delete(string patientId)
        {
            XDocument patientsDoc = XDocument.Load(_xmlFile);
            var query = from record in patientsDoc.Elements("Patients").Elements("Patient")
                        where record != null && record.Element("Id").Value == patientId.ToString()
                        select record;

            var toDelete = query.FirstOrDefault();
            if (toDelete != null)
            {
                toDelete.Remove();
                patientsDoc.Save(_xmlFile);
            }
        }

        public void MarkDeleted(string patientId)
        {
            XDocument patientsDoc = XDocument.Load(_xmlFile);

            var query = from record in patientsDoc.Elements("Patients").Elements("Patient")
                        where record != null && record.Element("Id").Value == patientId.ToString()
                        select record;

            var toDelete = query.FirstOrDefault();
            if(toDelete!=null)
            {
                toDelete.Element("IsDeleted").Value = "1";
                patientsDoc.Save(_xmlFile);
            }            
        }
    }
}