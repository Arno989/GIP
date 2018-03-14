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
            int id = (int)GridView.DataKeys[e.RowIndex].Value;

            _businesscode.DeleteClient(Convert.ToInt32(id));

            Response.Redirect("../Site/ClientPage.aspx");

        }
    }
}