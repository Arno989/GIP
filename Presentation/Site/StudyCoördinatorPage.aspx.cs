using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class StudyCoördinatorPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetStudyCoordinators(sortingPar); //--Var
                GridView.DataBind();
                ListBoxRel1();
            }
        }

        protected void ListBoxRel1()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel1";
                ListBox listbox = GridView.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationStudyCoordinatorHasDoctors(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

                if (Relations.Count != 0)
                {
                    List<DoctorCode> Rel1Raw = new List<DoctorCode>(); //--Var

                    for (int i2 = 0; i2 < Relations.Count; i2++)
                    {
                        string sortingPar = string.Format("WHERE Doctor_ID = {0}", Relations[i2]); //--Var
                        Rel1Raw = _businesscode.GetDoctors(sortingPar); //--Var
                        listbox.Items.Add(Rel1Raw[0].Name);
                    }
                }
                listbox.DataBind();
            }
        }


        protected void Edit(object sender, EventArgs e)
        {
            List<string> Record = new List<string>();
            List<int> DataSessionIDs = new List<int>();
            List<List<string>> ListDataSession = new List<List<string>>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;

                    if (chk.Checked)
                    {
                        DataSessionIDs.Add((int)GridView.DataKeys[i].Value);

                        for (int i2 = 1; i2 < GridView.Columns.Count - 1; i2++)
                        {
                            Record.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListDataSession.Add(Record);
                    }
                }
            }

            if (DataSessionIDs.Count != 0)
            {
                Session["DataID"] = DataSessionIDs;
                Session["ListDataSession"] = ListDataSession;
                Response.Redirect("../SiteEdit/StudyCoordinatorPageEdit.aspx"); //--Var
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);
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

                        if (_businesscode.GetRelationStudyCoordinatorHasDoctors(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationStudyCoordinatorHasDoctors(RecordID); //--Var
                        }
                        _businesscode.DeleteStudyCoördinator(RecordID); //--Var
                    }
                }
            }
            Response.Redirect("../Site/StudyCoordinatorPage.aspx"); //--Var
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/StudyCoordinatorPageEdit.aspx"); //--Var
        }
    }
}