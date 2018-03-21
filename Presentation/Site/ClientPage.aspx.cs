using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
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
            //GridView.DataSource = _businesscode.GetClients(sortingPar);
            //GridView.DataBind();
        }


        protected void Load_Gridview(object sender, EventArgs e)
        {
            GridView.DataSource = _businesscode.GetClients(sortingPar);
            GridView.DataBind();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)GridView.DataKeys[e.RowIndex].Value;

            _businesscode.DeleteClient(Convert.ToInt32(id));

            Response.Redirect("../Site/ClientPage.aspx");
        }
        
        /*
        #region Sort
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        public SortDirection GridViewSortDirection
        {
            get {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void GridView_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance
            DataTable dt = GetData().Tables[0];

            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;

            GridView.DataSource = dv;
            GridView.DataBind();
        }
        #endregion
        */

        protected void btnDelete_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                        if (chk.Checked)
                        {
                            int a = 5;
                        //delete functie
                        }
                        else
                        {
                            int a = 0;
                        //niets
                        }
                    }
                }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}