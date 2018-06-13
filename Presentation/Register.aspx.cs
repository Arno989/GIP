using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
    public partial class Register: System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();

        protected void Page_Load(object sender,EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender,EventArgs e)
        {
            string username = tbUsername.Text;
            string password = HashCode.Hash(tbPassword.Text);
            string email = tbEmail.Text;
            
            List<UserCode> userList = _businesscode.GetUsers(string.Format("WHERE Username = '{0}'",username));

            if (userList.Count == 0)
            {
                _businesscode.SetUser(username,email,password);
                Response.Redirect("/Login.aspx");
            }
            else
            {
                lbError.Text = "This account already exists";
                lbError.Visible = true;
            }
        }
    }
}