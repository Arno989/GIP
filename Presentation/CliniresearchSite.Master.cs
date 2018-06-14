using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
	public partial class Cliniresearch: System.Web.UI.MasterPage
	{
        private BusinessCode _business = new BusinessCode();

        protected void Page_Load(object sender,EventArgs e)
		{
            UserCode user = (UserCode) Session["authenticatedUser"];
            lbUser.Text = user.Username;
        }

        protected void BtnLogout_Click(object sender,EventArgs e)
        {
            Session["authenticatedUser"] = null;
            Response.Redirect("../index.aspx");
        }
    }
}