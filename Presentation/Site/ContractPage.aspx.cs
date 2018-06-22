using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class ContractPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Legal_country ASC";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || !IsPostBack)
            {
                UserCode user = (UserCode) Session["authenticatedUser"];
                if (user == null)
                {
                    Response.Redirect("../index.aspx");
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
            GridView.DataSource = _businesscode.GetContracts(sortingPar);
            GridView.DataBind();
            FillProject();
            FillClient();
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
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
                Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
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
                        _businesscode.DeleteContract(Convert.ToInt32(id), "");
                        CheckedOrNot = true;
                    }
                }
            }
            if(CheckedOrNot == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to delete.')", true);
            }
            else
            {
                Response.Redirect("../Site/ContractPage.aspx");
            }
        }

        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;

                if (e.SortExpression == "Legal_country")
                {
                    ViewState.Add("Sorting", "Legal Country");
                }
                else if (e.SortExpression == "Fee")
                {
                    ViewState.Add("Sorting", "Fee");
                }
                else if (e.SortExpression == "Start_Date")
                {
                    ViewState.Add("Sorting", "Start Date");
                }
                else if (e.SortExpression == "End_Date")
                {
                    ViewState.Add("Sorting", "End Date");
                }
                else if (e.SortExpression == "Project_ID")
                {
                    ViewState.Add("Sorting", "Project");
                }
                else if (e.SortExpression == "Client_ID")
                {
                    ViewState.Add("Sorting", "Client");
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
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<ContractCode> _contract = new List<ContractCode>();
                _contract = _businesscode.GetContracts("where Contract_ID = " + GridView.DataKeys[e.Row.RowIndex].Value);

                for (int i = 1; i < GridView.Columns.Count; i++)
                {
                    if (user.Type == "Admin")
                    {
                        UserCode _user = _businesscode.GetUsers("where User_ID = " + _contract[0].User_ID)[0];
                        e.Row.ToolTip = "First added on " + _contract[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _contract[0].Date_Last_Edited.ToString("dd-MMM-yyyy") + " by " + _user.Username;
                    }
                    else
                    {
                        e.Row.ToolTip = "First added on " + _contract[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _contract[0].Date_Last_Edited.ToString("dd-MMM-yyyy");
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
        
        public void FillProject()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //projectID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", GridView.DataKeys[i].Value);
                List<ContractCode> CurrentContract = new List<ContractCode>();
                CurrentContract = _businesscode.GetContracts(sortingPar1);
                int projectID = CurrentContract[0].ProjectID;

                //projectID omzetten naar project title
                string sortingPar2 = string.Format(" WHERE Project_ID = {0}", projectID);
                List<ProjectCode> ProjectRelation = new List<ProjectCode>();
                ProjectRelation = _businesscode.GetProjects(sortingPar2);
                string ProjectTitle = ProjectRelation[0].Title;

                GridView.Rows[i].Cells[5].Text = ProjectTitle;
            }
        }

        public void FillClient()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //projectID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", GridView.DataKeys[i].Value);
                List<ContractCode> CurrentContract = new List<ContractCode>();
                CurrentContract = _businesscode.GetContracts(sortingPar1);
                int clientID = CurrentContract[0].ClientID;

                //projectID omzetten naar project title
                string sortingPar2 = string.Format(" WHERE Client_ID = {0}", clientID);
                List<ClientCode> ClientRelation = new List<ClientCode>();
                ClientRelation = _businesscode.GetClients(sortingPar2);
                string ClientName = ClientRelation[0].Name;

                GridView.Rows[i].Cells[6].Text = ClientName;
            }
        }
    }
}