using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Site
{
	public partial class HomeSite: System.Web.UI.Page
	{
		protected void Page_Load(object sender,EventArgs e)
		{
            
		}

        protected void ButtonCRA_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/CRAPage.aspx");
        }

        protected void ButtonClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ClientPage.aspx");
        }

        protected void ButtonClientContract_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ContractPage.aspx");
        }

        protected void ButtonDepartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/DepartmentPage.aspx");
        }

        protected void ButtonDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/DoctorPage.aspx");
        }

        protected void ButtonEvaluation_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/EvaluationPage.aspx");
        }

        protected void ButtonHospital_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/HospitalPage.aspx");
        }

        protected void ButtonProjectManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ProjectManagerPage.aspx");
        }

        protected void ButtonProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ProjectPage.aspx");
        }

        protected void ButtonStudyCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/StudyCoordinatorPage.aspx");
        }

    }
}