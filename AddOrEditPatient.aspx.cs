using ShaneSampleApp.DataLayer;
using ShaneSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShaneSampleApp
{
    public partial class AddOrEditPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patientId = Request.QueryString["patientId"];
                if (patientId != null && patientId != "0")
                {
                    var repo = new PatientRepo();
                    var patientModel = repo.GetById(patientId);
                    if (patientModel == null)
                    {
                        return;
                    }

                    firstName.Text = patientModel.FirstName;
                    lastName.Text = patientModel.LastName;
                    email.Text = patientModel.Email;
                    phone.Text = patientModel.PhoneNumber;
                    patientIdField.Value = patientModel.Id;
                    createdDate.Value = patientModel.CreatedDate;
                    lastUpdatedDate.Value = patientModel.LastUpdatedDate;
                    gender.SelectedValue = patientModel.Gender;
                    notes.Text = patientModel.Notes;

                    registerOrEdit.InnerHtml = "Edit Patient";
                }
                else
                    registerOrEdit.InnerHtml = "Add New Patient";
            }
            
        }

        protected void submit_Click(object sender, EventArgs e)
        {            
            var repo = new PatientRepo();
            
            var patientModel= new PatientModel
            {
                Id=patientIdField.Value,
                CreatedDate=createdDate.Value,
                LastUpdatedDate = lastUpdatedDate.Value,
                FirstName =firstName.Text,
                LastName=lastName.Text,
                PhoneNumber= phone.Text,
                Email= email.Text,
                Gender=gender.SelectedValue,
                Notes=notes.Text
            };

            repo.AddOrUpdate(patientModel);
            Response.Redirect("~/Default");
        }
    }
}