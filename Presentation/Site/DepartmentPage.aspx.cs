using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class DepartmentPage: System.Web.UI.Page
	{
		BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";

        protected void Page_Load(object sender,EventArgs e)
		{
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetDepartments(sortingPar);
                GridView.DataBind();
            }
            FillHospital();
        }

        protected void Edit(object sender, EventArgs e)
        {
            List<string> List1 = new List<string>();
            List<List<string>> ListData = new List<List<string>>();
            List<int> DataIDs = new List<int>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        DataIDs.Add((int)GridView.DataKeys[i].Value);

                        for (int i2 = 1; i2 < GridView.Columns.Count; i2++)
                        {
                            List1.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListData.Add(List1);
                    }
                }
            }
            
            if (DataIDs.Count != 0)
            {
                Session["DataID"] = DataIDs;
                Session["ListDataSession"] = ListData;
                Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            bool CheckedOrNot = false;
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        int id = (int)GridView.DataKeys[i].Value;
                        _businesscode.DeleteDepartment(Convert.ToInt32(id), "");
                    }
                    else
                    {
                    }
                }
            }
            if (CheckedOrNot == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to delete.')", true);
            }
            else
            {
                Response.Redirect("../Site/DepartmentPage.aspx");
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
        }

        public void FillHospital()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //hospitalID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Department_ID = {0}", GridView.DataKeys[i].Value);
                List<DepartmentCode> CurrentDepartment = new List<DepartmentCode>();
                CurrentDepartment =  _businesscode.GetDepartments(sortingPar1);
                int hospitalID = CurrentDepartment[0].HospitalID;

                // hospitalID omzetten naar hospital name
                string sortingPar2 = string.Format(" WHERE Hospital_ID = {0}", hospitalID);
                List<HospitalCode> HospitalRelation = new List<HospitalCode>();
                HospitalRelation = _businesscode.GetHospitals(sortingPar2);
                string hospitalName = HospitalRelation[0].Name;

                GridView.Rows[i].Cells[4].Text = hospitalName;
            }
        }
    }
}