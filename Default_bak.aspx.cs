using ShaneSampleApp.DataLayer;
using ShaneSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShaneSampleApp
{
    public partial class _Default_bak : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                PatientsGrid.DataSource = PatientsDataSource();
                PatientsGrid.DataBind();
            }
        }

        DataView PatientsDataSource()
        {
            DataTable dt = new DataTable();            

            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));

            var repo = new PatientRepo();

            foreach (var patient in repo.GetAll())
            {
                var dr = dt.NewRow();
                dr[0] = patient.Id;
                dr[1] = patient.FirstName;
                dr[2] = patient.LastName;

                dt.Rows.Add(dr);
            }
            
            return new DataView(dt);

        }
    }
}