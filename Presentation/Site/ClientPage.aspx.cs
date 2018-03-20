using System;
using System.Collections.Generic;
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
            foreach (GridViewRow row in GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    var container = Master.FindControl("Body");
                    CheckBox chkRow = container.FindControl("cbEdit") as CheckBox;
                    if (chkRow.Checked == true)
                    {
                        Response.Redirect("../index.aspx");
                        //int id = Convert.ToInt16(row.Cells[1].Text);
                        //_businesscode.DeleteClient(id);
                    }
                }
            }

            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox CheckRow = (row.Cells[2].FindControl("cbEdit") as CheckBox);
            //        if (CheckRow.Checked)
            //        {
                        
            //        }
            //    }
            //}

            //CheckBox checkBox = (CheckBox)GridView.Rows[my_Data_From_Grid].Cells[2].Controls[0];
            //cbx_Test1_Active.Checked = checkBox.Checked;

            //foreach (GridViewRow rw in GridView.Rows)
            //{
            //    CheckBox chkBx = (CheckBox)rw.FindControl("cbEdit");
            //    if (chkBx != null && chkBx.Checked)
            //    {

            //        //int id = (int)GridView.DataKeys[0].Value;
            //        //id = grid1.Rows[0].Cells[3].Text.ToString();


            //    }
            //}

            //foreach (var gvItem in GridView)
            //{
            //    CheckBox chkItem = (CheckBox)gvItem.FindControl("cbEdit");
            //    if (chkItem.Checked)
            //    {
            //        //Do stuff
            //    }
            //}

            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        int id = (int)GridView.DataKeys[0].Value;
            //        CheckBox chkRow = (row.Cells[0].FindControl("cbEdit") as CheckBox);
            //        if (chkRow.Checked)
            //        {
            //            //string id = row.Cells[0].Text;
            //            //int id = (int)GridView.DataKeys[1].Value;
            //        }
            //    }
            //}
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}