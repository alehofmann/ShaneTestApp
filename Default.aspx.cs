using ShaneSampleApp.DataLayer;
using ShaneSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShaneSampleApp
{
    public partial class _Default : Page
    {
        public DataView PatientsDataView;
        public IList<PatientModel> PatientsList;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                var repo = new PatientRepo();
                PatientsList = repo.GetAll();


                foreach (PatientModel item in PatientsList)
                {
                    var tempRow = new TableRow();
                    tempRow.Cells.Add(new TableCell { Text = item.FirstName });
                    tempRow.Cells.Add(new TableCell { Text = item.LastName });
                    tempRow.Cells.Add(new TableCell { Text = item.GenderText });
                    tempRow.Cells.Add(new TableCell { Text = item.Email });
                    tempRow.Cells.Add(new TableCell { Text = item.PhoneNumber });
                    tempRow.Cells.Add(new TableCell { Text = item.Notes });

                    var editCell = new TableCell();
                    var tmpLinkButton = new LinkButton
                    {
                        CssClass = "btn btn-primary fa fa-pencil",
                        Text = ""
                    };
                    tmpLinkButton.Attributes.Add("patientId", item.Id);
                    tmpLinkButton.Click += new EventHandler(btnEdit_Click);
                    editCell.Controls.Add(tmpLinkButton);
                    tempRow.Cells.Add(editCell);

                    var deleteCell = new TableCell();
                    tmpLinkButton = new LinkButton
                    {
                        CssClass = "btn btn-primary fa fa-trash",
                        Text = "",
                    };
                    tmpLinkButton.Attributes.Add("patientId", item.Id);
                    tmpLinkButton.Click += new EventHandler(btnDelete_Click);
                    deleteCell.Controls.Add(tmpLinkButton);
                    tempRow.Cells.Add(deleteCell);

                    PatientsTable.Rows.Add(tempRow);
                }
                        
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            var repo = new PatientRepo();
            repo.MarkDeleted(button.Attributes["patientId"]);
            Response.Redirect("~/Default");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            Response.Redirect($"~/AddOrEditPatient?patientId={button.Attributes["patientId"]}");
        }

     
        protected void AddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddOrEditPatient");
        }
    }
}