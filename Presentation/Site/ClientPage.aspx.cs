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
            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox chkRow = (row.Cells[0].FindControl("btnDelete") as CheckBox);
            //        if (chkRow.Checked)
            //        {
            //            int id = Convert.ToInt16(row.Cells[2].Text);
            //            _businesscode.DeleteClient(id);
            //        }
            //    }
            //}

            foreach (GridViewRow row in GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[1].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //string id = row.Cells[0].Text;
                        //int id = (int)GridView.DataKeys[b.RowIndex].Value;
                    }
                }
            }
        }

    }
}