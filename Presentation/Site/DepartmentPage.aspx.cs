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
                Load_content();
            }
        }

        protected void Load_content()
        {
            GridView.DataSource = _businesscode.GetDepartments(sortingPar);
            GridView.DataBind();

            FillHospital();
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
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
                Session["ListDataSession"] = ListData;
                Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
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
                else if (e.SortExpression == "Phone1")
                {
                    ViewState.Add("Sorting", "Phone");
                }
                else if (e.SortExpression == "Hospital_ID")
                {
                    ViewState.Add("Sorting", "Hospital");
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