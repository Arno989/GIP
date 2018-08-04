using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
    public partial class Master_Page_2__0 : System.Web.UI.MasterPage
    {
        private BusinessCode _business = new BusinessCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserCode user = (UserCode)Session["authenticatedUser"];
            if (user == null)
                Response.Redirect("index.aspx");
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
                Response.Redirect("index.aspx");
            }
            return user;
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["authenticatedUser"] = null;
            Response.Redirect("index.aspx");
        }

        protected void BtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Site/ProfilePage.aspx");
        }

        protected void BtnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Site/AdministratorPage.aspx");
        }
    }
}