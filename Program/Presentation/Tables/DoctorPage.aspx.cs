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
            if (IsPostBack || !IsPostBack)
            {
                UserCode user = (UserCode) Session["authenticatedUser"];
                if (user == null)
                {
                    Response.Redirect("/index.aspx");
                }
            }
            if (!IsPostBack)
            {
                Load_content();
            }
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _businesscode.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void Load_content()
        {
            GridView.DataSource = _businesscode.GetDoctors(sortingPar); 
            GridView.DataBind();
            ListBoxRel1();
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
                ListBox listbox = GridView.Rows[i].Cells[10].FindControl(lbName) as ListBox;
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

        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;

                if (e.SortExpression == "Name")
                {
                    ViewState.Add("Sorting", "Name");
                }
                else if (e.SortExpression == "Email")
                {
                    ViewState.Add("Sorting", "E-mail");
                }
                else if(e.SortExpression == "Phone1")
                {
                    ViewState.Add("Sorting", "Phone 1");
                }
                else if(e.SortExpression == "Phone2")
                {
                    ViewState.Add("Sorting", "Phone 2");
                }
                else if(e.SortExpression == "Adress")
                {
                    ViewState.Add("Sorting", "Adress");
                }
                else if(e.SortExpression == "Postal_Code")
                {
                    ViewState.Add("Sorting", "Postal Code");
                }
                else if(e.SortExpression == "City")
                {
                    ViewState.Add("Sorting", "City");
                }
                else if(e.SortExpression == "Country")
                {
                    ViewState.Add("Sorting", "Country");
                }
                else if(e.SortExpression == "Specialisation")
                {
                    ViewState.Add("Sorting", "Specialisation");
                }
                else if(e.SortExpression == "CV")
                {
                    ViewState.Add("Sorting", "CV");
                }

                Load_content();
            }
        }

        protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                string imgAsc = @" <img src='..\Images\round_arrow_drop_up_black_18dp.png' title='Ascending' />";
                string imgDes = @" <img src='..\Images\round_arrow_drop_down_black_18dp.png' title='Descendng' />";

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        LinkButton lnkbtn = (LinkButton)e.Row.Cells[1].Controls[0];
                        try
                        {
                            lnkbtn = (LinkButton)cell.Controls[0];
                        }
                        catch
                        {
                            goto track1;
                        }
                        track1:
                        if (lnkbtn.Text == ViewState["Sorting"].ToString())
                        {
                            if (ViewState["SortDirection"] as string == "ASC")
                            {
                                lnkbtn.Text += imgAsc;
                            }
                            else
                                lnkbtn.Text += imgDes;
                        }
                    }
                }
            }
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.ID);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<DoctorCode> _doctor = new List<DoctorCode>();
                _doctor = _businesscode.GetDoctors("where Doctor_ID = " + GridView.DataKeys[e.Row.RowIndex].Value);

                for (int i = 1; i < GridView.Columns.Count; i++)
                {
                    if (user.Type == "Admin")
                    {
                        UserCode _user = _businesscode.GetUsers($"WHERE User_ID = {_doctor[0].User_ID};")[0];
                        e.Row.ToolTip = "First added on " + _doctor[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _doctor[0].Date_Last_Edited.ToString("dd-MMM-yyyy") + " by " + _user.Username;
                    }
                    else
                    {
                        e.Row.ToolTip = "First added on " + _doctor[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _doctor[0].Date_Last_Edited.ToString("dd-MMM-yyyy");
                    }
                }
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
    }
}