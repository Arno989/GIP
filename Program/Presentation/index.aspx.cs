using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
    public partial class Login: System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();

        protected void Page_Load(object sender,EventArgs e)
        {
            if (IsPostBack || !IsPostBack)
            {
                UserCode user = (UserCode) Session["authenticatedUser"];
                if (user != null)
                {
                    Response.Redirect("/Site/HomePage.aspx");
                }
            }
        }

        protected void BtnLogin_Click(object sender,EventArgs e)
        {
            string username = tbUsername.Text;

            try
            {
                List<UserCode> userList = _businesscode.GetUsers(string.Format("WHERE Username = '{0}'",username));
                string password = userList[0].Password;

                if (HashCode.Verify(tbPassword.Text,password))
                {
                    Session["authenticatedUser"] = userList[0];
                    Response.Redirect("/Site/HomePage.aspx");
                }
                else
                {
                    lbError.Text = "Incorrect username or password";
                    lbError.Visible = true;
                }
            }
            catch
            {
                lbError.Text = "User account doesn't exist";
                lbError.Visible = true;
            }
        }
    }
}