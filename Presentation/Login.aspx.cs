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

        }

        protected void BtnLogin_Click(object sender,EventArgs e)
        {
            string username = tbUsername.Text;

            List<UserCode> userList = _businesscode.GetUsers(string.Format("WHERE Username = '{0}'",username));
            string password = userList[0].Password.ToString();
            
            if (HashCode.Verify(tbPassword.Text,password))
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                lbError.Text = "Incorrect username or password";
                lbError.Visible = true;
            }
        }
    }
}