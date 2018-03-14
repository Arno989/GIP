using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

            TableCell cell = GridView.Rows[e.RowIndex].Cells[1];

            _businesscode.DeleteClient(Convert.ToInt32(cell.Text));

            Response.Redirect("../Site/ClientPage.aspx");

        }
    }
}