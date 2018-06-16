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
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);
            lbUser.Text = user.Username;

            if(user.Type == "Admin")
            {
                divAdmin.Attributes["style"] = "display: block;";
            }
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            try
            {
                user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            }
            catch
            {
                Session["authenticatedUser"] = null;
                Response.Redirect("../index.aspx");
            }
            return user;
        }

        protected void BtnLogout_Click(object sender,EventArgs e)
        {
            Session["authenticatedUser"] = null;
            Response.Redirect("../index.aspx");
        }

        protected void BtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/ProfilePage.aspx");
        }

        protected void BtnAdmin_Click(object sender,EventArgs e)
        {
            Response.Redirect("../Site/AdministratorPage.aspx");
        }
    }
}