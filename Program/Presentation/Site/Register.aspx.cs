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
            if (IsPostBack || !IsPostBack)
            {
                UserCode user = (UserCode) Session["authenticatedUser"];
                if (user != null)
                {
                    Response.Redirect("/Site/HomePage.aspx");
                }
            }
        }

        protected void BtnRegister_Click(object sender,EventArgs e)
        {
            string username = tbUsername.Text;
            string password = HashCode.Hash(tbPassword.Text);
            string email = tbEmail.Text;
            
            List<UserCode> userList = _businesscode.GetUsers(string.Format("WHERE Username = '{0}'",username));
            UserCode subject = new UserCode(0, tbUsername.Text, tbEmail.Text, HashCode.Hash(password), "Guest");

            if (userList.Count == 0)
            {
                try
                {
                    if (username != string.Empty && password != string.Empty && email != string.Empty)
                    {
                        if (_businesscode.IsValidEmail(email))
                        {
                            _businesscode.AddUser(subject);

                            Session["authenticatedUser"] = subject;
                            Response.Redirect("/Site/HomePage.aspx");
                        }
                        else
                        {
                            lbError.Text = "Please fill in a valid email adress";
                            lbError.Visible = true;
                        }
                    }
                    else
                    {
                        lbError.Text = "Please fill in all fields";
                        lbError.Visible = true;
                    }
                }
                catch
                {
                    lbError.Text = "Something went wrong";
                    lbError.Visible = true;
                }
            }
            else
            {
                lbError.Text = "This account already exists";
                lbError.Visible = true;
            }
        }
    }
}