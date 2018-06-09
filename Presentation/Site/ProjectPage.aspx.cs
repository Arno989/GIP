using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
    public partial class ProjectPage : System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = "ORDER BY Title ASC";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetProjects(sortingPar);
                GridView.DataBind();

                ListBoxRel1();
                ListBoxRel2();
                ListBoxRel3();
                ListBoxRel4();
            }
        }


        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/ProjectPageEdit.aspx");
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

                        for (int i2 = 1; i2 < GridView.Columns.Count - 1; i2++)
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
                Response.Redirect("../SiteEdit/ProjectPageEdit.aspx"); //--Var
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

                        if (_businesscode.GetRelationProjectHasCRAs(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationProjectHasCRAs(RecordID); //--Var
                        }
                        if (_businesscode.GetRelationProjectHasDoctors(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationProjectHasDoctors(RecordID); //--Var
                        }
                        if (_businesscode.GetRelationProjectHasHospitals(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationProjectHasHospitals(RecordID); //--Var
                        }
                        if (_businesscode.GetRelationProjectHasProjectManagers(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationProjectHasProjectManagers(RecordID); //--Var
                        }
                        _businesscode.DeleteContract(-1, string.Format("OR Project_ID = {0}", RecordID));
                        _businesscode.DeleteProject(RecordID); //--Var
                    }
                }
            }
            Response.Redirect("../Site/ProjectPage.aspx");
        }


        protected void ListBoxRel1()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel1";
                ListBox listbox = GridView.Rows[i].Cells[4].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationProjectHasCRAs(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

                if (Relations.Count != 0)
                {
                    List<CRACode> RelRaw = new List<CRACode>(); //--Var

                    for (int i2 = 0; i2 < Relations.Count; i2++)
                    {
                        sortingPar = string.Format("WHERE CRA_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                        RelRaw = _businesscode.GetCRAs(sortingPar); //--Var
                        listbox.Items.Add(RelRaw[0].Name);
                    }
                }
                listbox.DataBind();
            }
        }

        protected void ListBoxRel2()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel2";
                ListBox listbox = GridView.Rows[i].Cells[5].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationProjectHasDoctors(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

                if (Relations.Count != 0)
                {
                    List<DoctorCode> RelRaw = new List<DoctorCode>(); //--Var

                    for (int i2 = 0; i2 < Relations.Count; i2++)
                    {
                        sortingPar = string.Format("WHERE Doctor_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                        RelRaw = _businesscode.GetDoctors(sortingPar); //--Var
                        listbox.Items.Add(RelRaw[0].Name);
                    }
                }
                listbox.DataBind();
            }
        }

        protected void ListBoxRel3()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel3";
                ListBox listbox = GridView.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationProjectHasHospitals(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

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

        protected void ListBoxRel4()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                var container = Master.FindControl("Body");
                string lbName = "lbRel4";
                ListBox listbox = GridView.Rows[i].Cells[7].FindControl(lbName) as ListBox;
                List<int> Relations = _businesscode.GetRelationProjectHasProjectManagers(Convert.ToInt32(GridView.DataKeys[i].Value)); //--Var

                if (Relations.Count != 0)
                {
                    List<ProjectManagerCode> RelRaw = new List<ProjectManagerCode>(); //--Var

                    for (int i2 = 0; i2 < Relations.Count; i2++)
                    {
                        sortingPar = string.Format("WHERE ProjectManager_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                        RelRaw = _businesscode.GetProjectManagers(sortingPar); //--Var
                        listbox.Items.Add(RelRaw[0].Name);
                    }
                }
                listbox.DataBind();
            }
        }
    }
}