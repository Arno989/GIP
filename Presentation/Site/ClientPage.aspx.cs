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
	public partial class ClientSite: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
		
		protected void Page_Load(object sender,EventArgs e)
		{
			GridView.DataSource = _businesscode.GetClients();
			GridView.DataBind();
		}

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)GridView.DataKeys[e.RowIndex].Value;

            _businesscode.DeleteClient(Convert.ToInt32(id));

            Response.Redirect("../Site/ClientPage.aspx");
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = row.Cells[0].FindControl("cbEdit") as CheckBox;
                    if (chkRow.Checked)
                    {
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