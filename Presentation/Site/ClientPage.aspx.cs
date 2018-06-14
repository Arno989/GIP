using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
    public partial class ClientSite : System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";


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

        protected void Load_content()
        {
            GridView.DataSource = _businesscode.GetClients(sortingPar);
            GridView.DataBind();
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/ClientPageEdit.aspx");
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
                Response.Redirect("../SiteEdit/ClientPageEdit.aspx");
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
                            int id = (int)GridView.DataKeys[i].Value;
                            _businesscode.DeleteContract(-1, string.Format("OR Client_ID = {0}", id));
                            _businesscode.DeleteClient(Convert.ToInt32(id));
                        }
                    }
                }
            Response.Redirect("../Site/ClientPage.aspx");
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
                else if (e.SortExpression == "Adress")
                {
                    ViewState.Add("Sorting", "Adress");
                }
                else if (e.SortExpression == "Postal_Code")
                {
                    ViewState.Add("Sorting", "Postal Code");
                }
                else if (e.SortExpression == "City")
                {
                    ViewState.Add("Sorting", "City");
                }
                else if (e.SortExpression == "Country")
                {
                    ViewState.Add("Sorting", "Country");
                }
                else if (e.SortExpression == "Contact_Person")
                {
                    ViewState.Add("Sorting", "Contact Person");
                }
                else if (e.SortExpression == "Invoice_Info")
                {
                    ViewState.Add("Sorting", "Invoice Info");
                }
                else if (e.SortExpression == "Kind_of_Client")
                {
                    ViewState.Add("Sorting", "Kind of Client");
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
    }
}