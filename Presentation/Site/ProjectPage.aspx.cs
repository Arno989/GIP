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

        protected void Load_content()
        {
                GridView.DataSource = _businesscode.GetProjects(sortingPar);
                GridView.DataBind();

                ListBoxRel1();
                ListBoxRel2();
                ListBoxRel3();
                ListBoxRel4();
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

        protected void Edit(object sender, EventArgs e)
        {
            List<int> DataSessionIDs = new List<int>();
            List<List<string>> ListDataSession = new List<List<string>>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;

                    if (chk.Checked)
                    {
                        List<string> Record = new List<string>();
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
                Response.Redirect("../SiteEdit/ProjectPageEdit.aspx"); //--Var
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

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/ProjectPageEdit.aspx");
        }

        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;

                int sortColumnIndex = 0;
                if (e.SortExpression == "Title")
                {
                    sortColumnIndex = 1;
                    ViewState.Add("Sorting", "Title");
                }
                else if(e.SortExpression == "Start_date")
                {
                    sortColumnIndex = 2;
                    ViewState.Add("Sorting", "Start Date");
                }
                else
                {
                    sortColumnIndex = 3;
                    ViewState.Add("Sorting", "End Date");
                }

                if (sortColumnIndex != -1)
                {
                    // Call the AddSortImage helper method to add
                    // a sort direction image to the appropriate
                    // column header. 

                    //AddSortImage(sortColumnIndex, row);
                }

                Load_content();
            }
            //int sortColumnIndex = GetSortColumnIndex();

            //if (sortColumnIndex != -1)
            //{
            //    //AddSortImage(sortColumnIndex, b.Row);
            //}
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

            // Use the RowType property to determine whether the 
            // row being created is the header row. 
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    // Call the GetSortColumnIndex helper method to determine
            //    // the index of the column being sorted.
            //    if(e.ToString() == "title")
            //    {

            //    }
            //    int sortColumnIndex = 0;

            //    if (sortColumnIndex != -1)
            //    {
            //        // Call the AddSortImage helper method to add
            //        // a sort direction image to the appropriate
            //        // column header. 
            //        AddSortImage(sortColumnIndex, e.Row);
            //    }
            //}
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        void AddSortImage(int columnIndex, GridViewRow headerRow)
        {

            // Create the sorting image based on the sort direction.
            Image sortImage = new Image();
            if (GridView.SortDirection == SortDirection.Ascending)
            {
                sortImage.ImageUrl = "~/Images/Sort_down.png";
                sortImage.AlternateText = "Ascending Order";
            }
            else
            {
                sortImage.ImageUrl = "~/Images/Sort_down.png";
                sortImage.AlternateText = "Descending Order";
            }

            // Add the image to the appropriate header cell.
            headerRow.Cells[columnIndex].Controls.Add(sortImage);

        }
        
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}