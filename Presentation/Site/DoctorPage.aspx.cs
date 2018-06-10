using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class DoctorPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = "ORDER BY Name ASC";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetDoctors(sortingPar); //--Var
                GridView.DataBind();
                ListBoxRel1();
            }
        }


        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx"); //--Var
        }

        protected void Edit(object sender, EventArgs e)
        {
            List<int> DataIDs = new List<int>();
            List<List<string>> ListDataSession = new List<List<string>>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;

                    if (chk.Checked)
                    {
                        List<string> Record = new List<string>();
                        DataIDs.Add((int)GridView.DataKeys[i].Value);

                        for (int i2 = 1; i2 < GridView.Columns.Count -1; i2++)
                        {
                            Record.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListDataSession.Add(Record);
                    }
                }
            }

            if (DataIDs.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);

            }
            else if (DataIDs.Count > 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('You cannot edit more than 10 records at a time.')", true);
            }
            else
            {
                Session["DataID"] = DataIDs;
                Session["ListDataSession"] = ListDataSession;
                Response.Redirect("../SiteEdit/DoctorPageEdit.aspx"); //--Var
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        int RecordID = (int)GridView.DataKeys[i].Value;

                        if (_businesscode.GetRelationDoctorHasHospitals(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationDoctorHasHospitals(RecordID); //--Var
                        }
                        if (_businesscode.GetRelationDoctorHasStudyCoordinators(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationDoctorHasStudyCoordinators(RecordID); //--Var
                        }
                        if (_businesscode.GetRelationDoctorHasProjects(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationDoctorHasProjects(RecordID); //--Var
                        }
                        _businesscode.DeleteEvaluation(-1, string.Format("OR Doctor_ID = {0}", RecordID));
                        _businesscode.DeleteDoctor(RecordID); //--Var
                    }
                }
            }
            Response.Redirect("../Site/DoctorPage.aspx"); //--Var
        }


        protected void ListBoxRel1()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel1";
                ListBox listbox = GridView.Rows[i].Cells[11].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationDoctorHasHospitals(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

                if (Relations.Count != 0)
                {
                    List<HospitalCode> RelRaw = new List<HospitalCode>(); //--Var

                    for (int i2 = 0; i2 < Relations.Count; i2++)
                    {
                        sortingPar = string.Format("WHERE Hospital_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                        RelRaw = _businesscode.GetHospitals(sortingPar); //--Var
                        listbox.Items.Add(RelRaw[0].Name);
                    }
                }
                listbox.DataBind();
            }
        }
    }
}